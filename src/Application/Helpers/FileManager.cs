using System;
using System.IO;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.Helpers
{
    public class FileManager : IFileManager
    {
        public async Task<string> Upload(string path, IFormFile image, string webrootPath)
        {
            path += Guid.NewGuid() + "_" + image.FileName;

            var serverFolder = Path.Combine(webrootPath, path);

            await using (var stream = File.Create(serverFolder))
            {
                await image.CopyToAsync(stream);
            }

            return "/" + path;
        }

        public bool Delete(string url, string webRootPath)
        {
            var status = false;
            var uploadsFolder = Path.Combine(webRootPath, url);
            var path = Path.Combine(Directory.GetCurrentDirectory(), uploadsFolder);
            var file = new FileInfo(path);
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    file.Delete();
                    status = !File.Exists(path);
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