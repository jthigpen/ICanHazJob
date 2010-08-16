namespace ICanHazJob.Web.Models
{
    public interface IUploadedImageProcessor
    {
        void ResizeImage(string imageFilename, string destinationFilename);
    }
}