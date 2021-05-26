using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.ClaimsForRegisteredUser
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser,IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> identityRole, IOptions<IdentityOptions> identityOptions )
         :base(userManager,identityRole,identityOptions)
        {

        }
        protected async override Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Firstname", user.Firstname ?? "")); // key and value 
            identity.AddClaim(new Claim("Lastname", user.Lastname ?? ""));
            return identity;
        }
        //overrided the GenerateClaimsAsync method to have the custom claims for adding firstname and lastnamne to the claims list for logged in user
    }
}
