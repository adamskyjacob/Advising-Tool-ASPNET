using CSharpWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

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
        public IActionResult GetGraduateSchedule(GraduateRequest req)
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddSection()
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
        public IActionResult AddCourse()
        {
            return View();
        }
        public IActionResult AddCourseSection(CourseSection section)
        {
            CourseSection sectionCopy = section;
            sectionCopy.courseid = section.courseid!.Remove(0, section.area!.Length);
            string values = "'" + sectionCopy.courseid + "','" + sectionCopy.area + "','" + sectionCopy.time + "','" + sectionCopy.periodlength + "','" + sectionCopy.building + "','" + sectionCopy.room + "'";
            using MySqlConnection con = new("server=localhost,3306;database=advising;user=root;password=password;");
            using MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = @"INSERT INTO `coursesections` (`courseid`, `area`,`time`, `periodlength`, `building`, `room`) VALUES (" + values + ");";
            con.Open();
            try
            {
                cmd.ExecuteNonQueryAsync();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
                con.Close();
            }
            con.Close();
            return View(sectionCopy);
        }
        public IActionResult AddSheet(MajorTrackingSheet var)
        {
            using MySqlConnection con = new(constr);
            using MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = @"INSERT INTO `majortrack` (`AREA`,`PHYSED`,`ELECT`,`HUA`,`MQP`,`IQP`,`SECT`,`SOCSCI`,`REQ`) VALUES (@AREA,@PHYSED,@ELECT,@HUA,@MQP,@IQP,@SECT,@SOCSCI,@REQ);";
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
                return View(var);
            }
            con.Close();
            return View(var);
        }
        public IActionResult AddTrackingSheet()
        {
            return View();
        }
        public IActionResult AddGraduateSheet()
        {
            return View();
        }
        public IActionResult InsertCourse(Course var)
        {
            using MySqlConnection con = new(constr);
            using MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = @"INSERT INTO `courses` (`courseid`, `area`,`description`, `professor`,`name`) VALUES (@courseid, @area, @description, @professor, @name);";
            Course course = var;
            course.courseid = course.courseid!.Remove(0, var.area!.Length);
            BindParams(cmd, course);
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
                    courseid = "ERROR",
                    area = "ERROR",
                    description = "ERROR",
                    professor = "ERROR"
                });
            }
            con.Close();
            return View(new Course()
            {
                name = var.name,
                courseid = var.courseid,
                area = var.area,
                description = var.description,
                professor = var.professor
            });
        }
        private static void BindParams(MySqlCommand cmd, MajorTrackingSheet data)
        {
            foreach (var prop in data.GetType().GetProperties())
            {
                cmd.Parameters.Add(new MySqlParameter
                {
                    ParameterName = "@" + prop.Name,
                    DbType = DbType.String,
                    Value = prop.GetValue(data, null)
                });
            }
            return;
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
            return View();
        }
        public IActionResult RequestSchedule(UScheduleRequest req)
        {
            return View(req);
        }
        public IActionResult GraduateScheduling()
        {
            return View();
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
                            courseid = sdr["courseid"].ToString(),
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