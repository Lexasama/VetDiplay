using VetDisplay.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using VetDisplay.WebApp.Authentication;

namespace VetDisplay.WebApp.Controllers
{

    [Route("api/[controller]")]
    public class MediaController : Controller
    {
        readonly MediaGateway _mediaGateway;
        public MediaController(MediaGateway mediaGateway)
        {
            _mediaGateway = mediaGateway;
        }

        [HttpPost("uploadMedia")]
        public async Task<IActionResult> UploadMedia(IFormCollection model)
        {
            List<string> result = await _mediaGateway.UploadVideo(model.Files);
            if( result.Count == 0)
            {
                return Ok();
            }
            return Ok(result);
        }

        //[HttpPost("DownloadVideo")]
        //public async Task<IActionResult> DownloadVideo(string imageName)
        //{
        //    MemoryStream file = await _mediaGateway.DownloadVideo(imageName);
        //    string GetType = await _mediaGateway.GetContentType(imageName);
        //    return File(file, "application/octet-stream", "profilePic.jpg");
        //}
    }
}