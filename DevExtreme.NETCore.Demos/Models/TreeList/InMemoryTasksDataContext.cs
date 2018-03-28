using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevExtreme.NETCore.Demos.Models.TreeList {
    public class InMemoryTasksDataContext {
        IHttpContextAccessor _contextAccessor;
        IMemoryCache _memoryCache;

        public InMemoryTasksDataContext(IHttpContextAccessor contextAccessor, IMemoryCache memoryCache) {
            _contextAccessor = contextAccessor;
            _memoryCache = memoryCache;
        }

        public ICollection<EmployeeTask> Tasks {
            get {
                var session = _contextAccessor.HttpContext.Session;
                var key = session.Id + "_TreeListTasks";

                if (_memoryCache.Get(key) == null) {
                    _memoryCache.Set<ICollection<EmployeeTask>>(key, SampleData.SampleData.EmployeeTasks, new MemoryCacheEntryOptions {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                    session.SetInt32("dirty", 1);
                }

                return _memoryCache.Get<ICollection<EmployeeTask>>(key);
            }
        }
        public ICollection<TaskEmployee> Employees {
            get {
                return SampleData.SampleData.TaskEmployees;
            }
        }
        public void SaveChanges() {
            foreach (var task in Tasks.Where(a => a.Task_ID == 0)) {
                task.Task_ID = Tasks.Max(a => a.Task_ID) + 1;
            }
        }
    }
}