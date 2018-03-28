using DevExtreme.NETCore.Demos.Models.SampleData;
using DevExtreme.NETCore.Demos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevExtreme.NETCore.Demos.Controllers {
    public class GalleryController : Controller {
        public ActionResult Overview() {
            var images = new List<string>();
            foreach(var i in Enumerable.Range(1, 9))
                images.Add(Url.Content(String.Format("~/images/Gallery/{0}.jpg", i)));

            return View(new GalleryViewModel {
                Images = images
            });
        }

        public ActionResult ItemTemplate() {
            return View(SampleData.GalleryItems);
        }
    }
}