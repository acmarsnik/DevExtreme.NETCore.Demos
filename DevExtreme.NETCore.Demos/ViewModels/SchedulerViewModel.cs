using DevExtreme.NETCore.Demos.Models;
using System.Collections.Generic;

namespace DevExtreme.NETCore.Demos.ViewModels {
    public class SchedulerViewModel {
        public List<CinemaDataItem> CinemaData { get; set; }
        public List<Movie> Movies { get; set; }
        public List<Theatre> Theatres { get; set; }
    }
}