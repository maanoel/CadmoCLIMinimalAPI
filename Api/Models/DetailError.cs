using System.Collections.Generic;
using System.Text.Json;

namespace Api.Models
{
    public class DetailErro
    {
        public int Code { get; set; }

        public List<string>? Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}