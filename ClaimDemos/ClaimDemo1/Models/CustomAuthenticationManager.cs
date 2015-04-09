using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Web;

namespace ClaimDemo1.Models
{
    public class CustomAuthenticationManager : ClaimsAuthenticationManager
    {
        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
        {
            // incomingPrincipal in this case will be WindowsPrincipal....Already authenticated.
            if (incomingPrincipal == null ||
                        String.IsNullOrWhiteSpace(incomingPrincipal.Identity.Name))
                throw new SecurityException("Name claim missing");

            // Get Additional Claims here.
            string department = "Cutwater IT";
            var deptClaim = new Claim(" http://cutwater/claims/department ", department);
            var roleClaim = new Claim(ClaimTypes.Role, "Manager");
            
            ClaimsIdentity identity = (ClaimsIdentity)incomingPrincipal.Identity;
            identity.AddClaim(deptClaim);
            identity.AddClaim(roleClaim);
            
            return incomingPrincipal;
        }
    }
}