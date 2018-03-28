using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DevExtreme.NETCore.Demos.Controllers {
    public partial class FileUploaderController : Controller {
        #region FileUploading
        public ActionResult FileUploading() {
            return View();
        }

        [HttpPost]
        public ActionResult Upload() {
            // Learn more on the functionality of the dxFileUploader widget at:
            // http://js.devexpress.com/Documentation/Guide/UI_Widgets/UI_Widgets_-_Deep_Dive/dxFileUploader/

            var myFile = Request.Form.Files["myFile"];
            var targetLocation = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

            try {
                var path = Path.Combine(targetLocation, myFile.FileName);

                // Uncomment to save the file
                //using(var fileStream = System.IO.File.Create(path)) {
                //    myFile.CopyTo(fileStream);
                //}
            } catch {
                Response.StatusCode = 400;
            }

            return new EmptyResult();
        }
        #endregion

        #region FileSelection
        public ActionResult FileSelection() {
            return View();
        }

        [HttpPost]
        public ActionResult FileSelection(string firstName, string lastName, IFormFile photo) {
            // Learn to use the entire functionality of the dxFileUploader widget.
            // http://js.devexpress.com/Documentation/Guide/UI_Widgets/UI_Widgets_-_Deep_Dive/dxFileUploader/
            
            ViewBag.FirstName = firstName;
            ViewBag.LastName = lastName;
            ViewBag.Photo = "[No photo]";

            if(photo != null) {
                SaveFile(photo);
                ViewBag.Photo = photo.FileName;
            }
            
            return View("SubmissionResult");
        }

        void SaveFile(IFormFile file) {
            var targetLocation = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

            try {
                var path = Path.Combine(targetLocation, file.FileName);

                // Uncomment to save the file
                //using(var fileStream = System.IO.File.Create(path)) {
                //    myFile.CopyTo(fileStream);
                //}
            } catch {
                Response.StatusCode = 400;
            }
        }
        #endregion
    }
}