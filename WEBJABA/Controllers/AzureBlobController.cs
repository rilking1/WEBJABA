using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBJABA.Models;

namespace WEBJABA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AzureBlobController : ControllerBase
    {
        private readonly AzureBlobService _service;

        public AzureBlobController(AzureBlobService azservice)
        {
            _service = azservice;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            var response = await _service.UploadFiles(files);
            return Ok(response);
        }

        [HttpGet("BlobList")]
        public async Task<IActionResult> GetBlobList()
        {
            var response = await _service.GetUploadedBlob();
            return Ok(response);
        }
    }
}