using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Parkgin.Server.Api.HubConfig;
using Parkgin.Server.Api.Service;

namespace Parkgin.Server.Api.Controllers
{
    /// <summary>
    /// 개발환경 구축 테스트
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopController : ControllerBase
    {
        const String folderName = "files";
        readonly String folderPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        private readonly IConfiguration _configuration;
        private IHubContext<SignalRDataHub> _hub;
        private readonly IFileService _fileService;


        public DevelopController(IConfiguration configuration, IHubContext<SignalRDataHub> hub
            ,IFileService fileService)
        {
            _configuration = configuration;
            _fileService = fileService;
            _hub = hub;
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }
        [Route("uploadFiles")]
        [HttpPost]
        [AllowAnonymous]
        [Consumes("application/json", "application/form-data")]
        public IActionResult PostProfilePicture(List<IFormFile> files)
        {
            //var stream = file.OpenReadStream(); ;
            //var name = file.FileName;
            //var _fs = new FileService();
            _fileService.SaveFile(files, "");
            //_fs.SaveFile(files, "");
            //_env.IsStaging()
            return Ok();
        }

        [Route("uploadFilesT")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> PostPicture(IFormFile uploadedFile)
        {
            var uploadImagePath = _configuration.GetSection("UploadDirectory:ImageFiles").Value;
            try
            {
                var file = Request.Form.Files[0];
                //var folderName = Path.Combine("UploadedFiles", "Images");
                var folderName = uploadImagePath.ToString();
                //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(folderName, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        /// <summary>
        /// fileupload sample
        /// </summary>
        /// <remarks>
        /// remarks
        /// </remarks>
        /// <param name="postDataFiles"></param>
        /// <returns></returns>
        [Route("uploadFilesNParams")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> PostDatas([FromForm]PostDataFiles postDataFiles)
        {
            var uploadImagePath = _configuration.GetSection("UploadDirectory:ImageFiles").Value;
            try
            {
                var file = Request.Form.Files[0];
                //var folderName = Path.Combine("UploadedFiles", "Images");
                var folderName = uploadImagePath.ToString();
                //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(folderName, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        /// <summary>
        /// signalR Hub 연결테스트
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [Route("SIgnalR")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConnectSignalR(string message)
        {
            await _hub.Clients.All.SendAsync("signalRMessage", DateTime.Now.ToString() + "// message=" + message ).ConfigureAwait(false);
            
            return Ok(new { message});
        }

    }

    public class PostDataFiles
    {
        public IFormFile uploadedFile{ get; set; }
        public string ParkingLotIdx { get; set; }
        public string CarNo { get; set; }
    }
}