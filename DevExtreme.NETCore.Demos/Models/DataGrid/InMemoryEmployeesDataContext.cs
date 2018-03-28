using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevExtreme.NETCore.Demos.Models.DataGrid {
    public class InMemoryEmployeesDataContext {
        IHttpContextAccessor _contextAccessor;
        IMemoryCache _memoryCache;

        public InMemoryEmployeesDataContext(IHttpContextAccessor contextAccessor, IMemoryCache memoryCache) {
            _contextAccessor = contextAccessor;
            _memoryCache = memoryCache;
        }

        public ICollection<Employee> Employees {
            get {
                var session = _contextAccessor.HttpContext.Session;
                var key = session.Id + "_Employees";

                if(_memoryCache.Get(key) == null) {
                    _memoryCache.Set<ICollection<Employee>>(key, SampleData.SampleData.DataGridEmployees, new MemoryCacheEntryOptions {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                    session.SetInt32("dirty", 1);
                }

                return _memoryCache.Get<ICollection<Employee>>(key);
            }
        }

        public void SaveChanges() {
            foreach(var employee in Employees.Where(a => a.ID == 0)) {
                employee.ID = Employees.Max(a => a.ID) + 1;
            }
        }
    }
}