﻿using System.Collections.Generic;
using System.Net;

namespace JSD.SUNKU.DTO
{
    public class Result<T>
    {
        public HttpStatusCode Status { get; set; }
        public string Mensaje { get; set; }
        public T Resultado { get; set; }
        public Dictionary<string, string[]> Errors { get; set; } = new();

        public Result<T> BadRequest(string mensaje)
        {
            this.Status = HttpStatusCode.BadRequest;
            this.Errors.Add("error", new[] { mensaje });
            return this;
        }
        public Result<T> NotFound(string mensaje)
        {
            this.Status = HttpStatusCode.NotFound;
            this.Errors.Add("error", new[] { mensaje });
            return this;
        }
    }
}
