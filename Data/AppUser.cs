using Microsoft.AspNetCore.Identity;
using Shoppie.DataAccess.Models;

namespace Shoppie.DataAccess;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    public Address? Address { get; set; }
}

