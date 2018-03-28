using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevExtreme.NETCore.Demos.Models {
    public class InMemoryDemosDataContext {
        IHttpContextAccessor _contextAccessor;
        IMemoryCache _memoryCache;

        public InMemoryDemosDataContext(IHttpContextAccessor contextAccessor, IMemoryCache memoryCache) {
            _contextAccessor = contextAccessor;
            _memoryCache = memoryCache;
        }

        public ICollection<Demo> Demos {
            get {
                var session = _contextAccessor.HttpContext.Session;
                var key = session.Id + "_Demos";

                if (_memoryCache.Get(key) == null) {
                    _memoryCache.Set<ICollection<Demo>>(key, SampleData.SampleData.Demos, new MemoryCacheEntryOptions {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                    session.SetInt32("dirty", 1);
                }

                return _memoryCache.Get<ICollection<Demo>>(key);
            }
        }

        public void SaveChanges() {
            foreach (var demo in Demos.Where(a => a.Id == 0)) {
                demo.Id = Demos.Max(a => a.Id) + 1;
            }
        }
    }
}
