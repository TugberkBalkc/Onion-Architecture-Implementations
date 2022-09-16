using EksiSozluk.API.Application.Constansts;
using EksiSozluk.API.Application.Exceptions.Authorization;
using EksiSozluk.API.Application.Exceptions.BusinessLogic;
using EksiSozluk.API.Application.Exceptions.Database;
using EksiSozluk.API.Application.Exceptions.InternalServer;
using EksiSozluk.API.Application.Exceptions.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Utilities.Middlewares.ExceptionHandling
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";

            if (exception.GetType() == typeof(BusinessLogicException))
                return HandleBusinessLogicException(httpContext, exception);
            else if (exception.GetType() == typeof(AuthorizationException))
                return HandleAuthorizationException(httpContext, exception);
            else if (exception.GetType() == typeof(ValidationException))
                return HandleValidationException(httpContext, exception);
            else if (exception.GetType() == typeof(DatabaseException))
                return HandleDatabaseException(httpContext, exception);
            else
                return HandleInternalServerException(httpContext, exception);
        }

        private Task HandleBusinessLogicException(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);

            var businessLogicException = (BusinessLogicException)exception;

            var exceptionHeaders = businessLogicException.Message.Split(',');

            var exceptionDetails = new BusinessLogicExceptionDetails
            {
                Title = exceptionHeaders[0],
                Detail = exceptionHeaders[1],
                RequestName = _next.Method.Name,
                StatusCode = StatusCodes.Status400BadRequest,
                ThrownDate = DateTime.Now
            };

            return httpContext.Response.WriteAsync(exceptionDetails.ToString());
        }

        private Task HandleAuthorizationException(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.Unauthorized);

            var authorizationException = (AuthorizationException)exception;

            var exceptionHeaders = authorizationException.Message.Split(',');

            var exceptionDetails = new AuthorizationExceptionDetails
            {
                Title = exceptionHeaders[0],
                Detail = exceptionHeaders[1],
                RequestedUserName = exceptionHeaders[2],
                StatusCode = StatusCodes.Status401Unauthorized,
                ThrownDate = DateTime.Now
            };

            return httpContext.Response.WriteAsync(exceptionDetails.ToString());
        }
        private Task HandleValidationException(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);

            var validationException = (ValidationException)exception;

            var exceptionErrors = validationException.Errors;

            var exceptionDetails = new ValidationExceptionDetails
            {
                Title = ServerTitles.Warning,
                Detail = ServerMessages.ValidationFailed,
                Errors = exceptionErrors,
                StatusCode = StatusCodes.Status400BadRequest,
                ThrownDate = DateTime.Now
            };

            return httpContext.Response.WriteAsync(exceptionDetails.ToString());
        }
        private Task HandleDatabaseException(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);

            var databaseException = (DatabaseException)exception;

            var exceptionHeaders = databaseException.Message.Split(',');

            var exceptionDetails = new DatabaseExceptionDetails
            {
                Title = exceptionHeaders[0],
                Detail = exceptionHeaders[1],
                DatabaseName = "Ekşi Sözlük",
                StatusCode = StatusCodes.Status400BadRequest,
                ThrownDate = DateTime.Now
            };

            return httpContext.Response.WriteAsync(exceptionDetails.ToString());
        }
        private Task HandleInternalServerException(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);

            var internalServerException = (InternalServerException)exception;

            var exceptionHeaders = internalServerException.Message.Split(',');

            var exceptionDetails = new InternalServerExceptionDetails
            {
                Title = exceptionHeaders[0],
                Detail = exceptionHeaders[1],
                ServerName = "Server.EksiSozluk.API",
                StatusCode = StatusCodes.Status500InternalServerError,
                ThrownDate = DateTime.Now
            };

            return httpContext.Response.WriteAsync(exceptionDetails.ToString());
        }
    }
}
