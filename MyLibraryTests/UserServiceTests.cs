using MyLibrary;

namespace MyLibraryTests
{
    public class UserServiceTests
    {
        [Theory]
        [InlineData("abc@qq.com", "123456", "666666")]
        public async Task ChangeNewPassword_Test(string email, string oldPassword, string newPassword)
        {
            var userRepositoryMock = new UserRepositoryMock(email, oldPassword);
            UserService sut = new UserService(userRepositoryMock);
            var actualResult = await sut.ChangeNewPasswordAsync(email, oldPassword, newPassword);
            Assert.True(actualResult);
            Assert.Equal(1, userRepositoryMock.UpdateCallCount);
        }

        public class UserRepositoryMock : IUserRepository
        {
            public string Email { get; set; }
            public string OldPassword { get; set; }

            public UserRepositoryMock(string email, string oldPassword)
            {
                Email = email;
                OldPassword = oldPassword;
            }

            public int UpdateCallCount { get; private set; } = 0;

            public Task<User> GetByEmailAsync(string email)
            {
                return Task.FromResult(new User(1, Email, OldPassword));
            }
            public Task<bool> UpdateAsync(User user)
            {
                UpdateCallCount++;
                return Task.FromResult(true);
            }
        }
    }
}
