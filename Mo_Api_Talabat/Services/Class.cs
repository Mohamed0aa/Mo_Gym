using Share;
using System.Security.Claims;

namespace Mo_Api_Talabat.Services
{
    public class LoggedInUser : ILoggedInUser
    {


        public string? UserId { get; }

        private readonly IHttpContextAccessor _HttpContextAccessor;
        public LoggedInUser(IHttpContextAccessor httpContextAccessor)
        {
            _HttpContextAccessor = httpContextAccessor;
            UserId=_HttpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.PrimarySid);
        }
          
    }
}
