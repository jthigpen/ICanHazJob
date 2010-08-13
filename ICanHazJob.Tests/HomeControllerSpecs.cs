using System;
using System.Web.Mvc;
using Bones.Test;
using ICanHazJob.Web.Controllers;
using NUnit.Framework;

namespace ICanHazJob.Tests
{
    public class HomeControllerSpecs
    {
        [TestFixture]
        public class When_requesting_the_homepage : ContextSpecification
        {
            private HomeController controller;
            private ViewResult result;

            protected override void EstablishContext()
            {
                controller = new HomeController();
            }

            protected override void Because()
            {
                result = controller.Index() as ViewResult;   
            }

            [Test]
            public void should_render_homepage()
            {
                result.ViewName.ShouldEqual(string.Empty);
            }
        }
    }
}