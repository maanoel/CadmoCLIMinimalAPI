using System.Collections.Generic;

namespace Api.Models
{
    public class ResponseModel
    {
        public bool Operation { get; set; }

        public List<string>? Messages { get; set; }

        public object? Data { get; set; }
    }
}