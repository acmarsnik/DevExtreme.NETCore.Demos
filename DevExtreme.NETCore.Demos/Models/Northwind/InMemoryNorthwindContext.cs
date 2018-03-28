using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevExtreme.NETCore.Demos.Models.Northwind {
    public class InMemoryNorthwindContext {
        NorthwindContext _nwind;
        IHttpContextAccessor _contextAccessor;
        IMemoryCache _memoryCache;

        public InMemoryNorthwindContext(NorthwindContext nwind, IHttpContextAccessor contextAccessor, IMemoryCache memoryCache) {            
            _nwind = nwind;
            _memoryCache = memoryCache;
            _contextAccessor = contextAccessor;
        }

        public DbSet<Customer> Customers {            
            get { return _nwind.Customers; }
        }

        public DbSet<Order_Detail> Order_Details {
            get { return _nwind.Order_Details; }
        }

        public ICollection<Order> Orders {
            get {
                var session = _contextAccessor.HttpContext.Session;
                var key = session.Id + "_Orders";

                if(_memoryCache.Get(key) == null) {                    
                    _memoryCache.Set<ICollection<Order>>(key, _nwind.Orders.ToList(), new MemoryCacheEntryOptions {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    });
                    session.SetInt32("dirty", 1);
                }

                return _memoryCache.Get<ICollection<Order>>(key);
            }
        }

        public DbSet<Shipper> Shippers {
            get { return _nwind.Shippers; }
        }

        public void SaveChanges() {
            foreach(var order in Orders.Where(o => o.OrderID == 0)) {
                order.OrderID = Orders.Max(o => o.OrderID) + 1;
            }
        }

    }
}
