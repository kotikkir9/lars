using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Helpers
{
    public class FileHandler
    {
        private readonly IWebHostEnvironment _hostEnv;

        public FileHandler(IWebHostEnvironment hostEnv)
        {
            _hostEnv = hostEnv;
        }

        public async Task<string> UploadDocument(IFormFile file, string path)
        {
            if (file.Length > 0)
            {
                var root = Path.Combine(_hostEnv.ContentRootPath, path);
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var filePath = Path.Combine(root, uniqueFileName);

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return $"{path}/{uniqueFileName}";
            }

            return string.Empty;
        }

        public bool DeleteFile(string filePath)
        {
            string fullPath = Path.Combine(_hostEnv.ContentRootPath, filePath);

            if(File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return true;
            }

            return false;
        }
    }
}
