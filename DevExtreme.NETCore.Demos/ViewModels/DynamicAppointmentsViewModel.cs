using DevExtreme.NETCore.Demos.Models;
using DevExtreme.NETCore.Demos.Models.SampleData;
using System.Collections.Generic;

namespace DevExtreme.NETCore.Demos.ViewModels {
    public class DynamicAppointmentsViewModel {
        public List<DynamicAppointment> Appointments { get; set; }

        public List<DynamicAppointmentsResource> Resources { get; set; }
    }
}