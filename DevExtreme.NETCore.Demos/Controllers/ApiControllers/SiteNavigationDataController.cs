using DevExtreme.NETCore.Demos.Models.Menu;
using Microsoft.AspNetCore.Mvc;

namespace DevExtreme.NETCore.Demos.Controllers.ApiControllers {

    [Route("api/[controller]")]
    public class SiteNavigationDataController : Controller {

        [HttpGet]
        public object Get(string demoController, string demoAction) {
            return Menu.Get(demoController, demoAction, Url);
        }        
    }
}
