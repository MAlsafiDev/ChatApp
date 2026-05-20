using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Common
{
    public class Response<T>
    {
        public bool Succeeded { get; set; }

        public string Message { get; set; } = string.Empty;

        public List<string> Errors { get; set; } = new();

        public T? Data { get; set; }

        public object? Meta { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
