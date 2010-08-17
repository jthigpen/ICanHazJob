using System;
using System.Drawing;
using System.IO;
using ICanHazJob.Web.Models;

namespace ICanHazJob.Web.Services
{
    public class UploadedImageProcessor : IUploadedImageProcessor
    {
        private const int MaxWidth = 500;
        private const int MaxHeight = 700;

        public string ResizeImage(string imageFilename)
        {
            var image = Image.FromFile(imageFilename);

            var resizedImageFilename = string.Empty;

            if (IsOversizedImage(image))
            {
                resizedImageFilename = GetResizedImageFilename(imageFilename);

                ShrinkImage(image, resizedImageFilename);
            }
            return resizedImageFilename;
        }

        private void ShrinkImage(Image image, string resizedImageFilename)
        {
            var scale = CalculateImageScaleFactor(image);
            var resizedImage = ScaleImage(image, scale);
            resizedImage.Save(resizedImageFilename);
        }

        private Image ScaleImage(Image image, double scale)
        {
            int newWidth = (int)(image.Width * scale);
            int newHeight = (int)(image.Height * scale);
            return image.GetThumbnailImage(newWidth, newHeight, () => false, IntPtr.Zero);
        }

        private double CalculateImageScaleFactor(Image image)
        {
            double width = image.Width;
            double height = image.Height;
            var widthScale = MaxWidth / width;
            var heightScale = MaxHeight / height;
            return Math.Min(widthScale, heightScale);
        }

        private bool IsOversizedImage(Image image)
        {
            return image.Width > MaxWidth || image.Height > MaxHeight;
        }

        private static string GetResizedImageFilename(string filename)
        {
            var resizedImageFilename = Path.GetFileNameWithoutExtension(filename) + "-resized" + Path.GetExtension(filename);
            var imagePath = Path.GetDirectoryName(filename);

            return Path.Combine(imagePath, resizedImageFilename);
        }
    }
}