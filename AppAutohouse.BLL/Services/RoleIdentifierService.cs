using Microsoft.AspNetCore.Http;

namespace AppAutohouse.BLL
{
    public class RoleIdentifierService : IRoleIdentifierService
    {
        //private readonly UserManager<IdentityUser> userManager;
        //private readonly RoleManager<IdentityRole> roleManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public RoleIdentifierService(IHttpContextAccessor httpContextAccessor)
        {
            //this.userManager = userManager;
            //this.roleManager = roleManager;
            this.httpContextAccessor = httpContextAccessor;
        }
        public bool IsAdmin()
        {
            return httpContextAccessor.HttpContext.User.IsInRole("admin");
        }
        public bool IsManager()
        {
            return httpContextAccessor.HttpContext.User.IsInRole("manager");
        }
    }
}