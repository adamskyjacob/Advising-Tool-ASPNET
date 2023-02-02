namespace CSharpWebApp.Models
{
    public class NewCourseModel
    {
        public string course { get; set; }
        public string area { get; set; }
        public string description { get; set; }
        public string professor { get; set; }
        public List<string> aos { get; set; }
    }
}
