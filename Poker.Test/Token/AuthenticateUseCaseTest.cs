using Moq;
using Poker.CrossCutting.Extensions;
using Poker.Domain.Models;
using Poker.Domain.Repositories;
using Poker.Service.UseCases;

namespace Poker.Test.Token
{
    public class AuthenticateUseCaseTest
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly AuthenticateUseCase _authenticateUseCase;

        public AuthenticateUseCaseTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _authenticateUseCase = new AuthenticateUseCase(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Execute_ShouldReturnTrue_WhenCredentialsAreValid()
        {
            // Arrange
            var email = "test@example.com";
            var password = "password123";
            var name = "test";
            var hashedPassword = password.Hash();

            _userRepositoryMock
                .Setup(repo => repo.GetByEmail(email))
                .ReturnsAsync(new UserModel { Email = email, Password = hashedPassword, Name =  name});

            // Act
            var result = await _authenticateUseCase.Execute(email, password);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Execute_ShouldThrowUnauthorizedAccessException_WhenEmailNotFound()
        {
            // Arrange
            var email = "nonexistent@example.com";
            var password = "password123";

            _userRepositoryMock
                .Setup(repo => repo.GetByEmail(email))
                .ReturnsAsync((UserModel)null);

            // Act & Assert
            await Assert.ThrowsAsync<UnauthorizedAccessException>(() => _authenticateUseCase.Execute(email, password));
        }

        [Fact]
        public async Task Execute_ShouldReturnFalse_WhenPasswordIsInvalid()
        {
            // Arrange
            var email = "test@example.com";
            var password = "wrongpassword";
            var name = "test";
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword("correctpassword");

            _userRepositoryMock
                .Setup(repo => repo.GetByEmail(email))
                .ReturnsAsync(new UserModel { Email = email, Password = hashedPassword, Name = name });

            // Act
            var result = await _authenticateUseCase.Execute(email, password);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(null, "password123")]
        [InlineData("test@example.com", null)]
        [InlineData("", "password123")]
        [InlineData("test@example.com", "")]
        public async Task Execute_ShouldThrowNullReferenceException_WhenEmailOrPasswordIsNullOrEmpty(string email, string password)
        {
            // Act & Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => _authenticateUseCase.Execute(email, password));
        }
    }
}
