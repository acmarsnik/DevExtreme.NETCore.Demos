using System;
using System.Collections.Generic;
using System.Linq;

namespace DevExtreme.NETCore.Demos.Models {
    public class CountryPopulation {
        public string name { get; set; }
        public List<CityPopulation> items { get; set; }
    }
}