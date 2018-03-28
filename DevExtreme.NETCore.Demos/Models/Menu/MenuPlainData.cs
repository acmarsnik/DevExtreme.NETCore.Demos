using DevExtreme.NETCore.Demos.Models.Demos;

namespace DevExtreme.NETCore.Demos.Models.Menu {
    public class MenuPlainData {
        public string Id { get; set; }
        public string ParrentId { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; }

        public MenuPlainData(MvcDemoGroup group, MenuPlainData parrent = null) {
            Name = group.Name;
            if(parrent != null) {
                ParrentId = parrent.Id;
                Id = ParrentId + group.Name;
            } else {
                Id = group.Name;
            }
        }

        public MenuPlainData(MvcDemo demo, MenuPlainData parrent = null) {
            Name = demo.Title;
            Action = demo.Name;
            Controller = demo.Widget;
            if(parrent != null) {
                ParrentId = parrent.Id;
                Id = ParrentId + demo.Name;
            } else {
                Id = demo.Name;
            }
        }
    }
}