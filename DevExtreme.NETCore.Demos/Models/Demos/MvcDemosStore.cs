using Microsoft.AspNetCore.Hosting.Internal;
using System.IO;
using System.Linq;
using DevExtreme.NETCore.Demos.Models.Demos.Parsers;
using System.Collections.Generic;

namespace DevExtreme.NETCore.Demos.Models.Demos {
    public static class MvcDemosStore {

        public static List<MvcDemo> Demos = new List<MvcDemo>();
        public static List<MvcDemoGroup> Categories;
        static string contentRootPath;

        public static void Initialize(string rootPath) {
            contentRootPath = rootPath;
            Categories = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MvcDemoGroup>>(
                File.ReadAllText(Path.Combine(contentRootPath, "menuMeta.json"))).ToList();
            InitializeDemos();
        }

        public static MvcDemo GetDemo(string controller, string action) {
            return Demos.FirstOrDefault(d => (d.Widget == controller) && (d.Name == action));
        }

        static List<MvcDemo> GetGroupDemos(MvcDemoGroup group) {
            var demos = new List<MvcDemo>();
            if(group.Demos != null) {
                foreach(var demo in new List<MvcDemo>(group.Demos)) {
                    var viewPath = Path.Combine(contentRootPath, "Views", demo.Widget, string.Format("{0}.cshtml", demo.Name));
                    if(File.Exists(viewPath)) {
                        InitializeDemo(demo);
                        demos.Add(demo);
                    } else {
                        group.Demos.Remove(demo);
                    }
                }
            }
            if(group.Groups != null) {
                foreach(var secondGroup in new List<MvcDemoGroup>(group.Groups)) {
                    var groupDemos = GetGroupDemos(secondGroup);
                    if(groupDemos.Count == 0) {
                        group.Groups.Remove(secondGroup);
                    } else {
                        demos.AddRange(groupDemos);
                    }
                }
            }
            return demos;
        }

        static void InitializeDemo(MvcDemo demo) {
            var viewPath = Path.Combine(contentRootPath, "Views", demo.Widget, string.Format("{0}.cshtml", demo.Name));
            var controllerPath = Path.Combine(contentRootPath, "Controllers", string.Format("{0}Controller.cs", demo.Widget));
            var controller = new MvcDemoFile(new ActionTextParser(demo.Name)) {
                Path = controllerPath,
                Name = Path.GetFileName(controllerPath)
            };
            demo.Files.Add(controller);


            var view = new MvcDemoFile {
                Path = viewPath,
                Name = Path.GetFileName(viewPath)
            };
            demo.Files.Add(view);

            var stylesPath = GetContentItem("css", "DemosStyles", demo, "css");
            if(File.Exists(stylesPath)) {
                var styles = new MvcDemoFile {
                    Path = stylesPath,
                    Name = Path.GetFileName(stylesPath)
                };
                demo.Files.Add(styles);
                demo.HasStyles = true;
            }

            demo.Description = CommonMark.CommonMarkConverter.Convert(ReadDemoDescriptionFile(demo));

            if(demo.MvcAdditionalFiles != null) {
                demo.MvcAdditionalFiles.ForEach(f => {
                    var path = contentRootPath + f.Trim().Replace("/Content/", "/wwwroot/")
                            .Replace("/Scripts/", "/wwwroot/").Replace("/", Path.DirectorySeparatorChar.ToString());
                    var file = new MvcDemoFile {
                        Path = path,
                        Name = Path.GetFileName(path)
                    };
                    demo.Files.Add(file);
                });
            }

            demo.Files = demo.Files.OrderByDescending(f =>
                               f.Name.Contains("cshtml")
                            ).ThenByDescending(f =>
                              f.Name.Contains(demo.Widget.Replace("_", "") + "Controller.cs")
                            ).ThenByDescending(f =>
                              f.Name.Contains("Controller.cs")
                            ).ThenBy(f =>
                              f.Name.Contains(".css")
                            ).ToList();
            Demos.Add(demo);
        }

        static void InitializeDemos() {
            foreach(var category in new List<MvcDemoGroup>(Categories)) {
                var categoryDemos = GetGroupDemos(category);
                if(categoryDemos.Count == 0) {
                    Categories.Remove(category);
                } else {
                    Demos.AddRange(categoryDemos);
                }
            }
        }

        static string GetContentItem(string mainFolder, string targetFolder, MvcDemo demo, string fileExtension) {
            return Path.Combine(contentRootPath, "wwwroot", mainFolder, targetFolder, demo.Widget, string.Format("{0}." + fileExtension, demo.Name));
        }

        static string ReadDemoDescriptionFile(MvcDemo demo) {
            var result = string.Empty;
            var descriptionPath = GetContentItem("", "Descr", demo, "md");

            if(!File.Exists(descriptionPath)) {
                descriptionPath = GetContentItem("", "Descr/Temp", demo, "md");
            }

            if(File.Exists(descriptionPath)) {
                result = File.ReadAllText(descriptionPath);
                
            }

            return result;
        }
    }
}