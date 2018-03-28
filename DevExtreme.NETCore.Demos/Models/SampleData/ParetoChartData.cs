using System;
using System.Collections.Generic;
using System.Linq;

namespace DevExtreme.NETCore.Demos.Models.SampleData {
    public partial class SampleData {
        public static List<ParetoChartData> ParetoChartData {
            get {
                return new List<ParetoChartData> {
                    new ParetoChartData { complaint = "Pizza is cold", count = 780 },
                    new ParetoChartData { complaint = "Inadequate cheese quantity", count = 120 },
                    new ParetoChartData { complaint = "Not baked properly", count = 52 },
                    new ParetoChartData { complaint = "Delayed delivery", count = 1123 },
                    new ParetoChartData { complaint = "Damaged delivery", count = 321 },
                    new ParetoChartData { complaint = "Incorrect billing", count = 89 },
                    new ParetoChartData { complaint = "Wrong size delivered", count = 222 }
                };
            }
        }
    }
}