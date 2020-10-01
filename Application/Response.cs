using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public static class Response
    {
        public static Response<T> Fail<T>(string messgae, T data = default) =>
            new Response<T>(false, messgae, data);

        public static Response<T> Ok<T>(string message, T data) =>
            new Response<T>(true, message, data);
    }

    public class Response<T>
    {
        public Response(bool success, string msg, T data)
        {
            Success = success;
            Message = msg;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

    }
}
