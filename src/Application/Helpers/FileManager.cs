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

        public bool Delete(string url, string webRootPath)
        {
            var status = false;
            var uploadsFolder = Path.Combine(webRootPath, url);
            var path = Path.Combine(Directory.GetCurrentDirectory(), uploadsFolder);
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    status = true;
                }
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}