using FileUpload.Entities;
using Microsoft.EntityFrameworkCore;
using  FileUpload.Entities;
namespace FileUpload.Data
{
    public class DbContextClass: DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options) { }
        public DbSet<FileDetails> FileDetails { get; set; }
    }
}
