using Blogify.Identity.API.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Blogify.Identity.API.Domain.Entities
{
    public class User : IdentityUser<long>
    {
        public long RoleId { get; set; }
        public RoleEnum Role { get; set; }
    }
}
