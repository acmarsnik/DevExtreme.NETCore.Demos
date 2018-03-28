using System;
using System.Collections.Generic;
using System.Linq;
using DevExtreme.AspNet.Mvc;

namespace DevExtreme.NETCore.Demos.Models.SampleData {
    public partial class SampleData {
        public static List<Layout> GetLayouts() {
            List<Layout> result = new List<Layout>();
            int index = 0;
            foreach (string name in Enum.GetNames(typeof(PivotGridFieldChooserLayout))) {
                result.Add(new Layout {
                    Key = index++,
                    Name = name
                });
            }
            return result;
        }
    }
}