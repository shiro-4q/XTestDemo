namespace MyLibrary
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<bool> UpdateAsync(User user);
    }
}
