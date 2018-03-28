using DevExtreme.NETCore.Demos.Models;
using DevExtreme.NETCore.Demos.Models.SampleData;
using System.Collections.Generic;

namespace DevExtreme.NETCore.Demos.ViewModels {
    public class RecurringAppointmentsViewModel {
        public List<RecurringAppointment> Appointments { get; set; }

        public List<RecurringAppointmentsResource> Resources { get; set; }
    }
}