using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.Helpers
{
    public class FileManager : IFileManager
    {
        public async Task<string> Upload(string path, IFormFile image, string webrootPath)
        {
            path += Guid.NewGuid() + "_" + image.FileName;

            string serverFolder = Path.Combine(webrootPath, path);

            await image.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + path;
        }
    }
}