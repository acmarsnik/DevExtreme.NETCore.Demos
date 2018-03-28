using DevExtreme.NETCore.Demos.Models;
using DevExtreme.NETCore.Demos.Models.SampleData;
using System.Collections.Generic;

namespace DevExtreme.NETCore.Demos.ViewModels {
    public class AdaptiveAppointmentsViewModel {
        public List<AdaptiveAppointment> Appointments { get; set; }

        public List<AdaptiveAppointmentsResource> Resources { get; set; }
    }
}