using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevExtreme.NETCore.Demos.Models.DataGrid {
    public class InMemoryEmployeesValidationDataContext {
        IHttpContextAccessor _contextAccessor;
        IMemoryCache _memoryCache;

        public InMemoryEmployeesValidationDataContext(IHttpContextAccessor contextAccessor, IMemoryCache memoryCache) {
            _contextAccessor = contextAccessor;
            _memoryCache = memoryCache;
        }

        public ICollection<EmployeeValidation> Employees {
            get {
                var session = _contextAccessor.HttpContext.Session;
                var key = session.Id + "_EmployeesValidation";

                if(_memoryCache.Get(key) == null) {
                    var data = SampleData.SampleData.DataGridEmployees
                        .Where(employee => employee.ID <= 10)
                        .Select(employee => new EmployeeValidation() {
                            ID = employee.ID,
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            Phone = employee.Phone,
                            Position = employee.Position,
                            Email = employee.Email
                        })
                        .ToList();

                    _memoryCache.Set<ICollection<EmployeeValidation>>(key, data, new MemoryCacheEntryOptions {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                    session.SetInt32("dirty", 1);
                }

                return _memoryCache.Get<ICollection<EmployeeValidation>>(key);
            }
        }

        public void SaveChanges() {
            foreach(var employee in Employees.Where(a => a.ID == 0)) {
                employee.ID = Employees.Max(a => a.ID) + 1;
            }
        }
    }
}