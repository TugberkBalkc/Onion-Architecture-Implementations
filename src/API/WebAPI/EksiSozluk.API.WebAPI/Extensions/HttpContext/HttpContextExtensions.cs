using System.Security.Claims;

namespace EksiSozluk.API.WebAPI.Extensions.HttpContext
{
    public static class HttpContextExtensions
    {
        public static String GetUserId(this Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            return httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public static String GetUserFirstName(this Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            return httpContext.User.FindFirst(ClaimTypes.Name)?.Value;
        }

        public static String GetUserLastName(this Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            return httpContext.User.FindFirst(ClaimTypes.Surname)?.Value;
        }

        public static String GetUserEmail(this Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            return httpContext.User.FindFirst(ClaimTypes.Email)?.Value;
        }
    }
}
