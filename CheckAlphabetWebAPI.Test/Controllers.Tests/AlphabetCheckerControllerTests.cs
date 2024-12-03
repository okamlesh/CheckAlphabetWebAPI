using Microsoft.AspNetCore.Mvc;
using Moq;
using CheckAlphabetWebAPI.Controllers;
using CheckAlphabetWebAPI.Services;

namespace CheckAlphabetWebAPI.Test.Controllers.Tests
{
    [TestClass]
    public class AlphabetCheckerControllerTests
    {
        private readonly Mock<IAlphabetCheckerService> _serviceMock;
        private readonly AlphabetCheckerController _controller;

        public AlphabetCheckerControllerTests()
        {
            _serviceMock = new Mock<IAlphabetCheckerService>();
            _controller = new AlphabetCheckerController(_serviceMock.Object);
        }

        [TestMethod]
        public void CheckAlphabet_ShouldReturnOkWithTrue_WhenServiceReturnsTrue()
        {
            // Arrange
            string input = "The quick brown fox jumps over the lazy dog.";
            _serviceMock.Setup(s => s.ContainsAllAlphabets(input)).Returns(true);

            // Act
            var result = _controller.CheckAlphabet(input) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue((bool)result.Value);
        }

        [TestMethod]
        public void CheckAlphabet_ShouldReturnOkWithFalse_WhenServiceReturnsFalse()
        {
            // Arrange
            string input = "Hello World!";
            _serviceMock.Setup(s => s.ContainsAllAlphabets(input)).Returns(false);

            // Act
            var result = _controller.CheckAlphabet(input) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse((bool)result.Value);
        }

        [TestMethod]
        public void CheckAlphabet_ShouldReturnBadRequest_WhenInputIsNullOrEmpty()
        {
            // Act
            var result = _controller.CheckAlphabet("") as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Input string cannot be null or empty.", result.Value);
        }
    }
}

