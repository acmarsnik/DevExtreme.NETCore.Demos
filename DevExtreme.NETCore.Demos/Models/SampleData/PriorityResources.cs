using System;
using System.Collections.Generic;
using System.Linq;

namespace DevExtreme.NETCore.Demos.Models.SampleData {
    public partial class SampleData {
        public static List<PriorityResource> PriorityResources {
            get {
                return new List<PriorityResource> {
                    new PriorityResource {
                        Id = 1,
                        Text = "High priority",
                        Color = "#cc5c53"
                    },
                    new PriorityResource {
                        Id = 2,
                        Text = "Low priority",
                        Color = "#ff9747"
                    }
                };
            }
        }
    }
}
