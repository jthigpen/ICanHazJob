using System;
using System.Web.Mvc;
using Bones.Test;
using ICanHazJob.Web.Controllers;
using NUnit.Framework;

namespace ICanHazJob.Tests.Controllers
{
    public class ImageControllerSpecs
    {
        public class When_uploading_an_image : ContextSpecification
        {
            private ImageController controller;
            private ActionResult result;

            protected override void EstablishContext()
            {
                controller = new ImageController();
            }

            protected override void Because()
            {
                result = controller.Upload();
            }

            [Test]
            public void should_save_file_to_disk()
            {
                throw new NotImplementedException();
            }

            [Test]
            public void should_resize_image()
            {
                throw new NotImplementedException();
            }

            [Test]
            public void should_display_resized_image_to_user()
            {
                throw new NotImplementedException();
            }

            [Test]
            public void should_prompt_user_to_upload_another_image()
            {
                throw new NotImplementedException();
            }
        }
    }
}