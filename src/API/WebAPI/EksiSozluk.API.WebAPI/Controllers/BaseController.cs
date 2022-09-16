using EksiSozluk.API.WebAPI.Extensions.HttpContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.API.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
       
        protected Guid _userId => Guid.Parse(_httpContextAccessor.HttpContext.GetUserId());
        protected String _firstName => _httpContextAccessor.HttpContext.GetUserFirstName();
        protected String _lastName => _httpContextAccessor.HttpContext.GetUserLastName();
        protected String _email => _httpContextAccessor.HttpContext.GetUserEmail();

        protected bool CheckUserId(Guid userId)
        {
            return userId == Guid.Empty
                ? false
                : true;
        }

        protected bool CheckUserFirstName(String userFirstName)
        {
            return userFirstName == String.Empty
                ? false
                : true;
        }

        protected bool CheckUserLastName(String userLastName)
        {
            return userLastName == String.Empty
                ? false
                : true;
        }

        protected bool CheckUserEmail(String userEmail)
        {
            return userEmail == String.Empty
                ? false
                : true;
        }
    }
}
