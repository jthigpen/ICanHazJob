using System;
using System.IO;
using System.Web.Mvc;
using ICanHazJob.Web.Models;

namespace ICanHazJob.Web.Controllers
{
    public class ImageController : Controller
    {
        private IUploadedImageProcessor uploadedImageProcessor;

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save()
        {
            foreach (string file in Request.Files)
            {
                var uploadedFiles = Request.Files[file];
                if (uploadedFiles.ContentLength == 0)
                    continue;
                
                string savedFileName = Path.Combine(
                   AppDomain.CurrentDomain.BaseDirectory,
                   Path.GetFileName(uploadedFiles.FileName));
                
                uploadedFiles.SaveAs(savedFileName);
                uploadedImageProcessor.ResizeImage(savedFileName, null);
            }



            return View();
        }
    }
}