using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace VetDisplay.DAL
{
    public class MediaGateway
    {
        readonly string _connectionString;
        readonly string _path ;
        readonly string _pathForDownload = "";

        public MediaGateway(string connectionstring)
        {
            _connectionString = connectionstring;
            _path = "../VetDisplay.WebApp/wwwroot/Videos";
        }

        public async Task<List<string>> UploadVideo(IFormFileCollection files)
        {
            List<string> message = new List<string>();

            string path = _path + "/";

            this.ExistDirectory(path);
            IFormFile file = files[0];

            string fileName = file.FileName;

            fileName = file.FileName.Substring(fileName.LastIndexOf("."));
            string filePath = Path.Combine(path, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);

            }
            
            return message;
        }

        public async Task<string> GetContentType(string filename)
        {
            string path = _pathForDownload + filename;
            string extension = Path.GetExtension(path);
            return extension;
        }

        internal void ExistDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                var test = Directory.GetCurrentDirectory();
                Directory.CreateDirectory(path);
            }
        }
    }
}
