using System.Collections.Generic;

namespace Application.Models
{
    public class CategoryResult
    {
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }
    }
}