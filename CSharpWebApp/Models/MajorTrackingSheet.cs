using System.Text.Json.Nodes;

namespace CSharpWebApp.Models
{
    public class MajorTrackingSheet
    {
        public string AREA { get; set; }
        public int MQP { get; set; }
        public int IQP { get; set; }
        public int HUA { get; set; }
        public int PHYSED { get; set; }
        public int SOCSCI { get; set; }
        public int ELECT { get; set; }
        public string SECT { get; set; }
        public string REQ { get; set; }
    }
}
