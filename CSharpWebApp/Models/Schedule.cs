namespace CSharpWebApp.Models
{
    public class Schedule
    {
        List<Year> years { get; set; }
    }
    internal class Year
    {
        List<Term> terms { get; set; }
    }
    internal class Term
    {
        List<Course> courses { get; set; }
    }
}
