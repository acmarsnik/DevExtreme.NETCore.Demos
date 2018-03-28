using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevExtreme.NETCore.Demos.Models.DataGrid {
    public class InMemoryEmployeesByStateDataContext {
        IHttpContextAccessor _contextAccessor;
        IMemoryCache _memoryCache;

        public InMemoryEmployeesByStateDataContext(IHttpContextAccessor contextAccessor, IMemoryCache memoryCache) {
            _contextAccessor = contextAccessor;
            _memoryCache = memoryCache;
        }

        public ICollection<EmployeeByState> EmployeesByState {
            get {
                var session = _contextAccessor.HttpContext.Session;
                var key = session.Id + "_EmployeesByState";

                if(_memoryCache.Get(key) == null) {
                    _memoryCache.Set<ICollection<EmployeeByState>>(key, SampleData.SampleData.DataGridEmployeesByState, new MemoryCacheEntryOptions {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                    session.SetInt32("dirty", 1);
                }

                return _memoryCache.Get<ICollection<EmployeeByState>>(key);
            }
        }

        public void SaveChanges() {
            foreach(var employee in EmployeesByState.Where(a => a.ID == 0)) {
                employee.ID = EmployeesByState.Max(a => a.ID) + 1;
            }
        }
    }
}