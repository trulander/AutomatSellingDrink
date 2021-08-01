using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using AutomatSellingDrink.Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutomatSellingDrink.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController: ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public FileController(
            IFileService fileService,
            IMapper mapper)
        {
            _fileService = fileService;
            _mapper = mapper;
        }
        
        [ProducesResponseType(typeof(Contracts.File), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Contracts.Error), (int) HttpStatusCode.BadRequest)]
        [HttpPost("uploadfile")]
        public async Task<IActionResult> UploadFileAsync(IFormFile uploadedFile)
        {
            Core.Models.File result = null;
            if (uploadedFile != null)
            {
                try
                {
                    result = await _fileService.UploadFileAsync(uploadedFile);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            return Ok(_mapper.Map<Core.Models.File, Contracts.File>(result));

        }
    }
}