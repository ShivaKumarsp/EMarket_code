using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Models
{
    public class APIResponse<T>
    {

        public APIResponse()
        {
        }
        public int Code { get; set; }
        public string Id {get; set; }
        public string Message { get; set; }
        public T Entity { get; set; }
        public Dictionary<string, string> ErrorDetails { get; set; }
    }
}
