using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.Helpers
{
    public interface IFileManager
    { 
        Task<string> Upload(string path, IFormFile image, string webrootPath);
        bool Delete(string url,string webRootPath);
    }
}