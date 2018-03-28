using System.Collections.Generic;

namespace DevExtreme.NETCore.Demos.Models.Demos {
    public class MvcDemoGroup {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; }
        public List<MvcDemo> Demos { get; set; }
        public List<MvcDemoGroup> Groups { get; set; }
    }
}