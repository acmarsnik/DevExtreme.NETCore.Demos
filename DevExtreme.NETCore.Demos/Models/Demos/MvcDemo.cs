using System.Collections.Generic;

namespace DevExtreme.NETCore.Demos.Models.Demos {
    public class MvcDemo {
        public string Title { get; set; }
        public string Widget { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public List<MvcDemoFile> Files { get; set; }
        public bool HasStyles { get; set; }
        public List<string> MvcAdditionalFiles { get; set; }
        public bool Hidden { get; set; }

        public MvcDemo() {
            Files = new List<MvcDemoFile>();
        }
    }

}