using System.Collections.Generic;

namespace DevExtreme.NETCore.Demos.Models.SampleData {
    public partial class SampleData {
        public static List<Theatre> Theatres {
            get {
                return new List<Theatre> {
                    new Theatre { ID = 1, Text = "Cinema Hall 1" },
                    new Theatre { ID = 2, Text = "Cinema Hall 2" }
                };
            }
        }
    }
}