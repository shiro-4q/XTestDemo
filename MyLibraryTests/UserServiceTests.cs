using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using MyLibrary;

namespace MyLibraryTests
{
    public class UserServiceTests
    {
        // 不使用AutoFixture，手动创建UserRepositoryMock实例
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

        // 使用AutoFixture + AutoFixMoq 自动生成准备数据，自动注入实例
        // 使用[Frozen]，确保注入的UserRepository实例是同一个
        [Theory, AutoMoqData]
        public async Task ChangeNewPassword_Test_Successfully([Frozen] Mock<IUserRepository> repoMock, UserService sut, int id, string email, string oldPassowrd)
        {
            var user = new User(id, email, oldPassowrd);
            repoMock.Setup(r => r.GetByEmailAsync(email)).ReturnsAsync(user);
            repoMock.Setup(r => r.UpdateAsync(user)).ReturnsAsync(true);
            var actualResult = await sut.ChangeNewPasswordAsync(email, oldPassowrd, oldPassowrd + "_new");
            actualResult.Should().BeTrue();
            repoMock.Verify(r => r.UpdateAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
