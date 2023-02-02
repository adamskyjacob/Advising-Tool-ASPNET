using CSharpWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using MySqlX.XDevAPI.Relational;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CSharpWebApp.Controllers
{
    public class HomeController : Controller
    {
        private static readonly string constr = "server=localhost,3306;database=advising;user=root;password=password;";
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CourseView()
        {
            CourseViewData courseViewData = new()
            {
                courseList = CourseList()
            };
            return View(courseViewData);
        }
        public IActionResult Administration()
        {
            return View();
        }
        public IActionResult InsertCourse(Course var)
        {
            using MySqlConnection con = new(constr);
            using MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = @"INSERT INTO `courses` (`course`, `area`,`description`, `professor`) VALUES (@course, @area, @description, @professor);";
            BindParams(cmd, var);
            con.Open();
            try
            {
                cmd.ExecuteNonQueryAsync();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                con.Close();
                return View(new Course()
                {
                    course = "ERROR",
                    area = "ERROR",
                    description = "ERROR",
                    professor = "ERROR"
                });
            }
            con.Close();
            return View(new Course()
            {
                course = var.course,
                area = var.area,
                description = var.description,
                professor = var.professor
            });
        }
        private static void BindParams(MySqlCommand cmd, Course data)
        {
            foreach (var prop in data.GetType().GetProperties())
            {
                cmd.Parameters.Add(new MySqlParameter
                {
                    ParameterName = "@" + prop.Name,
                    DbType = DbType.String,
                    Value = prop.GetValue(data, null),
                });
            }
        }
        public IActionResult UndergraduateScheduling()
        {
            Dictionary<string, List<string>> dropdownData = new();
            dropdownData.Add("AOS", QueryDB("SELECT * FROM ", "studyarea"));
            return View(dropdownData);
        }
        public IActionResult GraduateScheduling()
        {
            Dictionary<string, List<string>> dropdownData = new();
            dropdownData.Add("AOS", QueryDB("SELECT * FROM ", "studyarea"));
            return View(dropdownData);
        }
        public List<string> QueryDB(string query, string table)
        {
            List<string> retList = new();
            using (MySqlConnection con = new(constr))
            {
                using MySqlCommand cmd = new(query + table);
                cmd.Connection = con;
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        retList.Add(sdr[table].ToString());
                    }
                }
                con.Close();
            }
            return retList;
        }
        public List<Course> CourseList()
        {
            List<Course> retList = new();
            using (MySqlConnection con = new(constr))
            {
                using MySqlCommand cmd = new("SELECT * FROM courses");
                cmd.Connection = con;
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        retList.Add(new Course()
                        {
                            course = sdr["course"].ToString(),
                            area = sdr["area"].ToString(),
                            description = sdr["description"].ToString(),
                            professor = sdr["professor"].ToString()
                        });
                    }
                }
                con.Close();
            }
            return retList;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}