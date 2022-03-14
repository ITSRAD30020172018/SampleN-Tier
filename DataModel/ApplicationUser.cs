using Microsoft.AspNetCore.Identity;

namespace DataModel
{
    public class ApplicationUser : IdentityUser
    {
        public string Fname { get; set; }
        public string SecondName { get; set; }

    }
}
