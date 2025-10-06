using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class AppUser:IdentityUser
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginDate { get; set; }

        
        public bool IsActive { get; set; } = true;
        public bool IsBanned { get; set; } = false;

       
      
    }
}
