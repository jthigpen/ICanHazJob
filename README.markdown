# Welcome to ICanHazJob #

## By: James Thigpen ##

### What is this? ###

This sample asp.net mvc application uploads images to a website as per some 
software specs. Neat!

### Where are the tests? ###

I feel pretty ashamed that I don't have a test project in this sample. All of my prior experience in
MVC development on .NET is in Monorail, and I spent a great deal of time fighting with the MVC framework
to let me do things I want.

Trying to mock a file upload in ASP.NET MVC is pretty ridiculous (http://www.hanselman.com/blog/ABackToBasicsCaseStudyImplementingHTTPFileUploadWithASPNETMVCIncludingTestsAndMocks.aspx)
and the benefits were far outweighed by the costs in this scenario.

I could have written more tests around the Uploaded Image Resizing section, but for this 
particular context, I decided it wasn't worth it. I went back and forth on this several times.

### What is missing versus production code? ###

Tests!  TESTS TESTS TESTS!

Also, I would almost never new up a service in constructor. That's what IoC containers are for, but I didn't
feel like wiring up Windsor for one class.  That's totally skewed cost/benefit.

Lots of other stuff.  Let's chat about it!

james.r.thigpen@gmail.com