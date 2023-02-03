using System.Text.Json.Nodes;

namespace CSharpWebApp.Models
{
    public class MajorTrackingSheet : TrackingSheet
    {
        public string AREA { get; set; }
        public int MQP { get { return 3; } }
        public int IQP
        {
            get { return 3; }
        }
        public int HUA { get { return 6; } }
        public int PHYSED { get { return 4; } }
        public int SOCSCI { get { return 2; } }
        public int ELECT { get { return 3; } }
        public string SECT { get; set; }

    }
}
