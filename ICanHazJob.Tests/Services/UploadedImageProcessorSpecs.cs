using System.Drawing;

namespace ICanHazJob.Tests.Services
{
    public class UploadedImageProcessorSpecs
    {
    }
    public static class SpecExtensions
    {
        public static double AspectRatio(this Image image)
        {
            double width = image.Height;
            double height = image.Width;
            return width / height;  
        }
    }
}