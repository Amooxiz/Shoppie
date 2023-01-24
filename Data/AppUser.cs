using Microsoft.AspNetCore.Identity;
using Shoppie.DataAccess.Models;

namespace Shoppie.DataAccess;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    public double PersonalDicount { get; set; } = 0;
    public string Name { get; set; }
    public string LastName { get; set; }
    public Address Address { get; set; }
    public ICollection<Offer> Offers { get; set; }
    public bool isAdmin { get; set; }
}