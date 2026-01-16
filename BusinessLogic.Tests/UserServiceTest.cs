using BusinessLogic.Services;
using Domain.Interfaces;
using Moq;
using Domain.Models;

namespace BusinessLogic.Tests
{
    public class UserServiceTest
    {
        private readonly UserService service;
        private readonly Mock<IUserRepository> userRepositoryMoq;
        public UserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IUserRepository>();

            repositoryWrapperMoq.Setup(x => x.User).Returns(userRepositoryMoq.Object);

            service = new UserService(repositoryWrapperMoq.Object);
        }

        //[Fact]
        //public async Task CreateAsync_NullUser_ShouldThrowNullArgumentException()
        //{
        //    // arrange
        //    var newUser = new User()
        //    {
        //        Login = "",
        //        PasswordHash = ""
        //    };

        //    // act
        //    var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => service.Create(null));

        //    // assert
        //    Assert.IsType<ArgumentNullException>(ex);
        //    userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
        //}

        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser(User user)
        {
            // arrange
            var newUser = user;

            // act
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            // assert
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] { new User() { Login = "", PasswordHash = "", RoleId = -1} },
                new object[] { new User() { Login = "log1", PasswordHash = "", RoleId = -2} },
                new object[] { new User() { Login = "", PasswordHash = "hash2", RoleId = -3} },
                new object[] { new User() { Login = "log", PasswordHash = "hash", RoleId = 1} }
            };
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            var newUser = new User()
            {
                Login = "log",
                PasswordHash = "hash",
                RoleId = 1
            };

            // act
            await service.Create(newUser);

            // assert
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Once);
        }
    }
}
