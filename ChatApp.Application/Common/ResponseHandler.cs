using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Common
{
    
    public abstract class ResponseHandler
    {
        public Response<T> Success<T>(T data, string message = "Success")
        {
            return new Response<T>
            {
                Data = data,
                Message = message,
                Succeeded = true,
                StatusCode = HttpStatusCode.OK
            };
        }

        public Response<T> Created<T>(T data, string message = "Created Successfully")
        {
            return new Response<T>
            {
                Data = data,
                Message = message,
                Succeeded = true,
                StatusCode = HttpStatusCode.Created
            };
        }

        public Response<T> Deleted<T>(string message = "Deleted Successfully")
        {
            return new Response<T>
            {
                Message = message,
                Succeeded = true,
                StatusCode = HttpStatusCode.OK
            };
        }

        public Response<T> BadRequest<T>(string message = "Bad Request",List<string>? errors = null)
        {
            return new Response<T>
            {
                Message = message,
                Errors = errors ?? new List<string>(),
                Succeeded = false,
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        public Response<T> Unauthorized<T>(string message = "Unauthorized")
        {
            return new Response<T>
            {
                Message = message,
                Succeeded = false,
                StatusCode = HttpStatusCode.Unauthorized
            };
        }

        public Response<T> NotFound<T>(string message = "Not Found")
        {
            return new Response<T>
            {
                Message = message,
                Succeeded = false,
                StatusCode = HttpStatusCode.NotFound
            };
        }

        public Response<T> UnprocessableEntity<T>(string message = "Unprocessable Entity")
        {
            return new Response<T>
            {
                Message = message,
                Succeeded = false,
                StatusCode = HttpStatusCode.UnprocessableEntity
            };
        }

        public Response<T> ServerError<T>(string message = "Internal Server Error")
        {
            return new Response<T>
            {
                Message = message,
                Succeeded = false,
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
    }
}
