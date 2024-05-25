using FileUpload.Entities;
using FileUpload.Services;
using MediatR;

namespace FileUpload.Commands
{
    public class AddFileUserCommandHandler : IRequestHandler<AddFileUserCommand, FileUploadModel>
    {
        private readonly IFileService _uploadService;
        public AddFileUserCommandHandler(IFileService uploadService)
        {
            _uploadService = uploadService;
        }
        public async Task<FileUploadModel> Handle(AddFileUserCommand request, CancellationToken cancellationToken)
        {
            await _uploadService.PostFileAsync(request.FileUploadModel);
            return request.FileUploadModel;
        }
    }
}
