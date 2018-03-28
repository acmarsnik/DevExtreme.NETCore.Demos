using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevExtreme.NETCore.Demos.Models {
    public class InMemoryListDataContext {
        IHttpContextAccessor _contextAccessor;
        IMemoryCache _memoryCache;

        public InMemoryListDataContext(IHttpContextAccessor contextAccessor, IMemoryCache memoryCache) {
            _contextAccessor = contextAccessor;
            _memoryCache = memoryCache;
        }

        public ICollection<ListItem> ListItems {
            get {
                var session = _contextAccessor.HttpContext.Session;
                var key = session.Id + "_ListItems";

                if(_memoryCache.Get(key) == null) {
                    _memoryCache.Set<ICollection<ListItem>>(key, SampleData.SampleData.ListPlainData.ToList(), new MemoryCacheEntryOptions {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                    session.SetInt32("dirty", 1);
                }

                return _memoryCache.Get<ICollection<ListItem>>(key);
            }
        }

        public void SaveChanges() {
            foreach(var listItem in ListItems.Where(a => a.ID == 0)) {
                listItem.ID = ListItems.Max(a => a.ID) + 1;
            }
        }
    }
}