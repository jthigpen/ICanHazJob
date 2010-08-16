using System;
using System.Drawing;
using System.IO;
using Bones.Test;
using ICanHazJob.Web.Services;
using NUnit.Framework;

namespace ICanHazJob.Tests.Services
{
    public class UploadedImageProcessorSpecs 
    {
        public abstract class UploadedImageProcessorContext : ContextSpecification
        {
            protected UploadedImageProcessor ImageProcessor;
            protected string ImageFilename = "Willow.jpg";
            protected string ResizedImageFilename;

            protected Image GetImageFromFile(string filename)
            {
                return Image.FromFile(filename);
            }

            protected string CreateUniqueFilename()
            {
                return Path.Combine("results", Guid.NewGuid() + ".jpg");
            }
        }

        public class When_resizing_an_image_that_is_within_size_constraints : UploadedImageProcessorContext
        {
            protected override void Because()
            {
                throw new NotImplementedException();
            }

            protected override void EstablishContext()
            {
                throw new NotImplementedException();
            }
        }

        public class When_resizing_an_image_that_is_too_wide : UploadedImageProcessorContext
        {
            protected override void EstablishContext()
            {
                Directory.CreateDirectory("results");
                ResizedImageFilename = CreateUniqueFilename();
                ImageProcessor = new UploadedImageProcessor();
            }

            protected override void Because()
            {
                ImageProcessor.ResizeImage(ImageFilename, ResizedImageFilename);
            }

            [Test]
            public void should_write_file_with_a_new_filename()
            {
                File.Exists(ResizedImageFilename).ShouldBeTrue();
            }

            [Test]
            public void should_resize_image_to_a_suitable_width()
            {
                GetImageFromFile(ResizedImageFilename).Width.ShouldBeLessThanOrEqualTo(500);
            }

            [Test]
            public void should_maintain_aspect_ratio()
            {
                GetImageFromFile(ResizedImageFilename).AspectRatio().ShouldEqual(GetImageFromFile(ImageFilename).AspectRatio());
            }

        }

        public class When_resizing_an_image_that_is_too_tall : UploadedImageProcessorContext
        {
            protected override void EstablishContext()
            {
                throw new NotImplementedException();
            }

            protected override void Because()
            {
                throw new NotImplementedException();
            }

            [Test]
            public void should_resize_image_to_a_suitable_width()
            {
                GetImageFromFile(ResizedImageFilename).Width.ShouldBeLessThanOrEqualTo(500);
            }

            [Test]
            public void should_maintain_aspect_ratio()
            {
                GetImageFromFile(ResizedImageFilename).AspectRatio().ShouldEqual(GetImageFromFile(ImageFilename).AspectRatio());
            }
        }

        public class When_resizing_an_image_that_is_too_tall_and_too_wide : ContextSpecification
        {
            protected override void Because()
            {
                throw new NotImplementedException();
            }

            protected override void EstablishContext()
            {
                throw new NotImplementedException();
            }
        }
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