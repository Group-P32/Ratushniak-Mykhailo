using Microsoft.AspNet.Identity.EntityFramework;

namespace JewelryStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Year { get; set; }
    }
}