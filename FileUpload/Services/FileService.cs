using FileUpload.Data;
using FileUpload.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Services
{
    public class FileService : IFileService
    {
        private readonly DbContextClass dbContextClass;

        public FileService(DbContextClass dbContextClass)
        {
            this.dbContextClass = dbContextClass;
        }

        public async Task PostFileAsync(FileUploadModel fileData)
        {
            try
            {
                var fileDetails = new FileDetails()
                {
                    ID = 0,
                    FileName = fileData.FileDetails.FileName,
                    FileType = fileData. FileType,
                };

                using (var stream = new MemoryStream())
                {
                    await fileData.FileDetails.CopyToAsync(stream);
                    fileDetails.FileData = stream.ToArray();
                }

                dbContextClass.FileDetails.Add(fileDetails);
                await dbContextClass.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while uploading file", ex);
            }
        }

        
        public async Task<FileDetails> GetFileByIdAsync(int id)
        {
            try
            {
                var file = await dbContextClass.FileDetails.FirstOrDefaultAsync(x => x.ID == id);
                if (file == null)
                {
                    throw new FileNotFoundException("File not found.");
                }
                return file;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while retrieving file", ex);
            }
        }
    }
}
