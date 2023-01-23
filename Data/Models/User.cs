namespace Shoppie.DataAccess.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public Address? Address { get; set; }
        public string PasswordHash { get; set; }
    }
}
