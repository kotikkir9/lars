using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;

namespace LarsV2.Controllers
{
    [ApiController]
    [Route("files")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment _hostEnv;

        public FileController(IWebHostEnvironment hostEnv)
        {
            _hostEnv = hostEnv;
        }

        [HttpGet("cv/{fileName}")]
        public IActionResult OpenCvPDF(string fileName)
        {
            var document = Path.Combine(_hostEnv.ContentRootPath, "files/cv" , fileName);

            if (System.IO.File.Exists(document))
            {
                return PhysicalFile(document, "application/pdf");
            }

            return NotFound();
        }
    }
}
