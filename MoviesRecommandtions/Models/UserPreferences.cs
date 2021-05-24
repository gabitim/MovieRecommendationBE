using Microsoft.AspNetCore.Identity;

namespace MoviesRecommandtions.Models
{
    public class UserPreferences : IdentityUser
    {
        public string Preferences { get; set; }

    }
}
