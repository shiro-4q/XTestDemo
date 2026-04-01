namespace MyLibrary
{
    public class UserService(IUserRepository repository)
    {
        private readonly IUserRepository _repository = repository;

        public async Task<bool?> ChangeNewPasswordAsync(string email, string oldPassword, string newPassword)
        {
            var user = await _repository.GetByEmailAsync(email) ?? throw new Exception("user not found");
            if (!user.ValidatePassword(oldPassword))
                return false;
            bool result = true;
            user.ChangePassword(newPassword);
            result = await _repository.UpdateAsync(user);
            return result;
        }
    }
}
