using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectSm
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Version { get; set; }
        public Object Data { get; set; }
    }
}
