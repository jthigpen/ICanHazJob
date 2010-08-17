namespace ICanHazJob.Web.Models
{
    public interface IUploadedImageProcessor
    {
        string ResizeImage(string imageFilename);
    }
}