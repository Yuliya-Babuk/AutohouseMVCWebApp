using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AppAutohouse.BLL
{
    public class RoleIdentifierService : IRoleIdentifierService
    {
        //private readonly UserManager<IdentityUser> userManager;
        //private readonly RoleManager<IdentityRole> roleManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public RoleIdentifierService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager
            ,IHttpContextAccessor httpContextAccessor)
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