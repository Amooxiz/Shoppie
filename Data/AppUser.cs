using Microsoft.AspNetCore.Identity;
using Shoppie.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace Shoppie.DataAccess;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    [Range(0, 1)]
    public double PersonalDicount { get; set; } = 0;
    public string Name { get; set; }
    public string LastName { get; set; }
    public Address Address { get; set; }
    public bool isAdmin { get; set; }
}