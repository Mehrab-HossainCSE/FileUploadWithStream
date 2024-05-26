using FileUpload.Entities;
using FileUpload.Services;
using MediatR;

namespace FileUpload.Queries
{
    public class GetUserFileQueryHandler : IRequestHandler<GetUserFileQuery, FileDetails>
    {
        private readonly IFileService _uploadService;
        public GetUserFileQueryHandler(IFileService uploadService)
        {
            _uploadService = uploadService;
        }
        public Task<FileDetails> Handle(GetUserFileQuery request, CancellationToken cancellationToken)
        {
            return _uploadService.GetFileByIdAsync(request.Id);
        }
    }
}
