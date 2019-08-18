using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;

namespace VetDisplay.DAL
{
    public class VideoGateway
    {
        readonly string _connectionString;
        readonly string _path;

        public VideoGateway( string connectionString)
        {
            _connectionString = connectionString;
            _path = "../VetDisplay.WebApp/wwwroot/Videos";
        }

        public async  Task<List<string>> UploadVideo(IFormFileCollection files)
        {
            List<string> message = new List<string>();
            string path = _path + "/";

            this.ExistDirectory(path);
            IFormFile file = files[0];

            string fileName = file.FileName;

            fileName = file.FileName.Substring( fileName.LastIndexOf("."));
            string filePath = Path.Combine(path, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
                
            }


                return message;
        }

        internal void ExistDirectory( string path)
        {
            if( !Directory.Exists( path ) )
            {
                var test = Directory.GetCurrentDirectory();
                Directory.CreateDirectory(path);
            }
        }
    }
}
