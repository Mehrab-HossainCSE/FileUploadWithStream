using FileUpload.Entities;
using MediatR;

namespace FileUpload.Queries
{
   public record GetUserFileQuery(int Id) : IRequest<FileDetails>;


}
