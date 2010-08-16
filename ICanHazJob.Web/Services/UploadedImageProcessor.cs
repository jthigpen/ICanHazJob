using System;
using System.Drawing;
using System.IO;
using ICanHazJob.Web.Models;

namespace ICanHazJob.Web.Services
{
    public class UploadedImageProcessor : IUploadedImageProcessor
    {
        public void ResizeImage(string imageFilename, string destinationFilename)
        {
            var image = Image.FromFile(imageFilename);

            
            
            var displayImage = image.GetThumbnailImage(500, (int) Math.Round(image.Height * (500D / image.Width)), () => false, IntPtr.Zero);
            displayImage.Save(destinationFilename);
        }

        private static string GetResizedImageFilename(string filename)
        {
            var resizedImageFilename = Path.GetFileNameWithoutExtension(filename) + "-resized" + Path.GetExtension(filename);
            var imagePath = Path.GetDirectoryName(filename);

            return Path.Combine(imagePath, resizedImageFilename);
        }
    }
}