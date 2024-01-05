namespace GameSharing.Account.Service
{
    public class RegisterRepresantation
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RegisterRepresantation(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
