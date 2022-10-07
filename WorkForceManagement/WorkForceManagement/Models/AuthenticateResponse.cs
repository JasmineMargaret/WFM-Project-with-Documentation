namespace WorkForceManagement.Models
{
    public class AuthenticateResponse
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            UserName = user.UserName;
            Name = user.Name;
            Role = user.Role;
            Email = user.Email;
            Token = token;
        }
    }
}
