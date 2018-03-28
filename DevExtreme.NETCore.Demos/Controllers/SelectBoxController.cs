using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DevExtreme.NETCore.Demos.Models.SampleData;
using DevExtreme.NETCore.Demos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace DevExtreme.NETCore.Demos.Controllers {
    public class SelectBoxController : Controller {
        #region Overview
        public ActionResult Overview() {
            return View(new SelectBoxViewModel {
                Items = SampleData.Electronics.Select(i => i.Name)
            });
        }

        [HttpGet]
        public ActionResult GetProducts(DataSourceLoadOptions loadOptions) {
            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(SampleData.Electronics, loadOptions)), "application/json");
        }
        #endregion

        // GetItems are duplicated for the demo purposes
        #region SearchAndEditing
        public ActionResult SearchAndEditing() {
            return View(new SelectBoxViewModel {
                Items = SampleData.Electronics.Select(i => i.Name)
            });
        }

        [HttpGet]
        public ActionResult GetItems(DataSourceLoadOptions loadOptions) {
            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(SampleData.Electronics, loadOptions)), "application/json");
        }
        #endregion

        #region CustomizeDropDownButton
        public ActionResult CustomizeDropDownButton() {
            return View(SampleData.Electronics.Take(5));
        }

        [HttpGet]
        public ActionResult GetProductNames(DataSourceLoadOptions loadOptions) {
            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(SampleData.Electronics.Take(5).Select(i => i.Name), loadOptions)), "application/json");
        }
        #endregion

        public ActionResult GroupedItems() {
            return View(SampleData.Electronics);
        }
    }
}