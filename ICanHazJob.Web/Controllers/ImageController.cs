using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using ICanHazJob.Web.Services;

namespace ICanHazJob.Web.Controllers
{
    public class ImageController : Controller
    {
        private readonly UploadedImageProcessor uploadedImageProcessor;

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

            ViewData["imageFilename"] = "/images/" + Path.GetFileName(displayFilename);

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

        private void CreateImagesDirectory()
        {
            var imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
            if (!Directory.Exists(imagePath)) Directory.CreateDirectory(imagePath);
        }

        private string GetImageFilename(HttpPostedFileBase uploadedFiles)
        {
            var savedFilename = Path.Combine(Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "images"),
                Path.GetFileName(uploadedFiles.FileName));
            return savedFilename;
        }
    }
}
