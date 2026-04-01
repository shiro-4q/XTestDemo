namespace MyLibrary
{
    public class User
    {
        public int Id { get; init; }
        public string Email { get; init; } = null!;
        public string Password { get; private set; } = null!;

        public User() { }

        public User(int id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }

        public bool ValidatePassword(string password)
        {
            return password == Password;
        }
    }
}
