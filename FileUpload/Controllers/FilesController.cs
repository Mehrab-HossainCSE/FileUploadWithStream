using FileUpload.Commands;
using FileUpload.Entities;
using FileUpload.Queries;
using FileUpload.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("PostSingleFile")]
        public async Task<ActionResult> PostSingleFile([FromForm] FileUploadModel fileDetails)
        {
            if (fileDetails == null)
            {
                return BadRequest("File details cannot be null.");
            }

            try
            {
                var command = new AddFileUserCommand(fileDetails);
                await _mediator.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        [HttpGet("DownloadFileById")]
        public async Task<ActionResult> DownloadFile(int id)
        {
            if (id < 1)
            {
                return BadRequest("Invalid file ID.");
            }

            try
            {
                var query = new GetUserFileQuery(id);
                var file = await _mediator.Send(query);
                return File(new MemoryStream(file.FileData), "application/octet-stream", file.FileName);
            }
            catch (FileNotFoundException)
            {
                return NotFound("File not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
