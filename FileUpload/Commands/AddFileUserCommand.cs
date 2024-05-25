using FileUpload.Entities;
using MediatR;

namespace FileUpload.Commands;

public record AddFileUserCommand(FileUploadModel FileUploadModel) :IRequest<FileUploadModel>;


