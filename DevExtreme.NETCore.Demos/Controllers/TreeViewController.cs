using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DevExtreme.NETCore.Demos.Models;
using DevExtreme.NETCore.Demos.Models.SampleData;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DevExtreme.NETCore.Demos.Controllers {
    public class TreeViewController : Controller {
        #region HierarchicalDataStructure
        public ActionResult HierarchicalDataStructure() {
            return View();
        }

        [HttpGet]
        public ActionResult GetHierarchicalData(DataSourceLoadOptions loadOptions) {
            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(TreeViewHierarchicalData.Products, loadOptions)), "application/json");
        }
        #endregion

        #region FlatDataStructure
        public ActionResult FlatDataStructure() {
            return View();
        }

        [HttpGet]
        public ActionResult GetPlainData(DataSourceLoadOptions loadOptions) {
            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(TreeViewPlainData.Products, loadOptions)), "application/json");
        }
        #endregion

        #region ItemSelectionAndCustomization
        public ActionResult ItemSelectionAndCustomization() {
            return View();
        }

        [HttpGet]
        public ActionResult SuperMartOfTheWest(DataSourceLoadOptions loadOptions) {
            var currentStore = TreeViewHierarchicalData.SuperMartOfTheWest.Items;

            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(new List<Product> {
                currentStore[0],
                currentStore[1],
                currentStore[3]
            }, loadOptions)), "application/json");
        }

        #endregion

        public ActionResult VirtualMode() {
            return View();
        }

        public ActionResult LoadDataOnDemand() {
            return View();
        }

        #region TreeViewWithSearchBar
        public ActionResult TreeViewWithSearchBar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetHierarchicalDataForSearch(DataSourceLoadOptions loadOptions)
        {
            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(TreeViewHierarchicalDataForSearch.Products, loadOptions)), "application/json");
        }
        #endregion
    }
}