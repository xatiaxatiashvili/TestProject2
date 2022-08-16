using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using TestProject2.Core.Application.Commons;
using TestProject2.Core.Application.Exceptions;

namespace TestProject2.Presentation.WebApi.Extensions.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;
    

        public ExceptionHandler(RequestDelegate next) =>
            (this.next) = (next);


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string titleText = "One or more validation errors occurred.";
            var statusCode = (int)HttpStatusCode.BadRequest;
            var traceId = Activity.Current?.Id ?? context?.TraceIdentifier;

            switch (exception)
            {
                case ApplicationBaseException e:
                    statusCode = (int)e.StatusCode;
                    break;
                case FluentValidation.ValidationException _:
                    break;
                case OperationCanceledException _:
                    titleText = "Operation Is Canceled.";
                    break;
                case Exception _:                  
                    exception = new Exception("Internal Server Error.");
                    titleText = "Internal Server Error.";
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }


            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(
            JsonSerializer.Serialize(Response.Failure(
                titleText: titleText,
                statusCode: statusCode,
                traceId: traceId,
                exception: exception
            )));
        }
    }
}
