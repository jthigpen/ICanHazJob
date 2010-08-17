using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using ICanHazJob.Web.Models;
using ICanHazJob.Web.Services;

namespace ICanHazJob.Web.Controllers
{
    public class ImageController : Controller
    {
        private readonly IUploadedImageProcessor uploadedImageProcessor;

        public ImageController()
        {
            uploadedImageProcessor = new UploadedImageProcessor();
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save()
        {
            var savedFilename = SaveUploadedFile();
            var displayFilename = uploadedImageProcessor.ResizeImage(savedFilename);

            ViewData["imageFilename"] = displayFilename;

            return View("Upload");
        }

        private string SaveUploadedFile()
        {
            var savedFilename = string.Empty;
            if (Request.Files.Count != 1) throw new InvalidOperationException("Can only upload 1 file at a time.");

            foreach (string file in Request.Files)
            {
                var uploadedFiles = Request.Files[file];
                if (uploadedFiles.ContentLength == 0)
                    continue;

                savedFilename = GetImageFilename(uploadedFiles);
                uploadedFiles.SaveAs(savedFilename);
            }
            return savedFilename;
        }

        private string GetImageFilename(HttpPostedFileBase uploadedFiles)
        {
            var savedFilename = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                Path.GetFileName(uploadedFiles.FileName));
            return savedFilename;
        }
    }
}