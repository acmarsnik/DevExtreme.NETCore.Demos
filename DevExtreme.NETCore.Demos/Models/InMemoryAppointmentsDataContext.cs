using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevExtreme.NETCore.Demos.Models {
    public class InMemoryAppointmentsDataContext {
        IHttpContextAccessor _contextAccessor;
        IMemoryCache _memoryCache;

        public InMemoryAppointmentsDataContext(IHttpContextAccessor contextAccessor, IMemoryCache memoryCache) {
            _contextAccessor = contextAccessor;
            _memoryCache = memoryCache;
        }

        public ICollection<Appointment> Appointments {
            get {
                var session = _contextAccessor.HttpContext.Session;
                var key = session.Id + "_Appointments";


                if(_memoryCache.Get(key) == null) {
                    _memoryCache.Set<ICollection<Appointment>>(key, SampleData.SampleData.Appointments, new MemoryCacheEntryOptions {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                    session.SetInt32("dirty", 1);
                }

                return _memoryCache.Get<ICollection<Appointment>>(key);
            }
        }

        public void SaveChanges() {
            foreach(var appointment in Appointments.Where(a => a.AppointmentId == 0)) {
                appointment.AppointmentId = Appointments.Max(a => a.AppointmentId) + 1;
            }
        }
    }
}
