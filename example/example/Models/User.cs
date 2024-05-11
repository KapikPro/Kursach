using Microsoft.AspNetCore.Identity;

namespace example.Models
{
    public class User: IdentityUser
    {
        public DateTime Date { get; set; }
    }
}
