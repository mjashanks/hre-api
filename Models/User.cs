namespace Hre.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Bio { get; set; }
        public string Region { get; set; }
        public string Role { get; set; }
        public string ProfilePicExtension {get; set; }
    }
}