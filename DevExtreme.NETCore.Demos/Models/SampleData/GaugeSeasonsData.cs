using System;
using System.Collections.Generic;
using System.Linq;

namespace DevExtreme.NETCore.Demos.Models.SampleData {
    public partial class SampleData {
        public static List<Season> GaugeSeasonsData = new List<Season> {
            new Season {
                Name = "Summer",
                Mean = 35,
                Min = 28,
                Max = 38
            },
            new Season {
                Name = "Autumn",
                Mean = 24,
                Min = 20,
                Max = 32
            },
            new Season {
                Name = "Winter",
                Mean = 18,
                Min = 16,
                Max = 23
            },
            new Season {
                Name = "Spring",
                Mean = 27,
                Min = 18,
                Max = 31
            }
        };
    }
}