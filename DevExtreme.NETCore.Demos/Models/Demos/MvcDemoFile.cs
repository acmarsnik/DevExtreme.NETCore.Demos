using System.IO;
using System.Xml.Serialization;
using DevExtreme.NETCore.Demos.Models.Demos.Parsers;

namespace DevExtreme.NETCore.Demos.Models.Demos {
    public class MvcDemoFile {
        IParser parser;
        public MvcDemoFile() { }

        public MvcDemoFile(IParser parser) {
            this.parser = parser;
        }

        public string Name { get; set; }

        string content;
        public string Content {
            get {
                if(string.IsNullOrEmpty(content)) {
                    var fileText = File.ReadAllText(Path);
                    if(parser != null) {
                        content = parser.Parse(fileText);
                    } else {
                        content = fileText;
                    }
                }

                return content;
            }
        }

        public string Path { get; set; }
    }
}