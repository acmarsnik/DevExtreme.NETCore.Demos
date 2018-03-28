using DevExtreme.NETCore.Demos.Models;
using DevExtreme.NETCore.Demos.Models.SampleData;
using System.Collections.Generic;

namespace DevExtreme.NETCore.Demos.ViewModels {
    public class SchedulerResourcesViewModel {
        public List<AppointmentWithResources> Appointments { get; set; }
        public List<OwnerResource> Owners { get; set; }
        public List<RoomResource> Rooms { get; set; }
        public List<PriorityResource> Priorities { get; set; }
    }
}