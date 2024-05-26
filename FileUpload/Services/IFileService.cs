using FileUpload.Entities;

namespace FileUpload.Services
{
    public interface IFileService
    {
        public Task PostFileAsync(FileUploadModel fileUploadModel);

       

        public Task<FileDetails> GetFileByIdAsync(int fileName);
    }
}
