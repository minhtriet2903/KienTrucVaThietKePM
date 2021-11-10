using System;
using System.Linq;
using System.Security.Claims;

namespace ASC.Utilities
{
    public static class ClaimsPrincipalExtensions
    {
        public static CurrentUser GetCurrentUserDetails(this ClaimsPrincipal principal)
        {
            if (!principal.Claims.Any())
                return null;
            var name = principal.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c =>
                c.Value).SingleOrDefault();
            var email = principal.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c =>
                c.Value).SingleOrDefault();
            var role = principal.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c =>
                c.Value).ToArray();
            var isActive = Boolean.Parse(principal.Claims.Where(c => c.Type == "IsActive").Select(c => c.Value).SingleOrDefault());
            if (name == null)
            {
                return new CurrentUser
                {
                    Name = "hello",
                    Email = "email",
                    Roles = null,
                    IsActive = true
                };
            }
            return new CurrentUser
            {
                Name = name,
                Email = email,
                Roles = role,
                IsActive = isActive,
            };
        }
    }
}
