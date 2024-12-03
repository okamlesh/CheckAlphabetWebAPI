using CheckAlphabetWebAPI.Services;

namespace CheckAlphabetWebAPI.Test
{
    [TestClass]
    public class AlphabetCheckerServiceTests
    {
        private readonly IAlphabetCheckerService _service;

        public AlphabetCheckerServiceTests()
        {
            _service = new AlphabetCheckerService();
        }

        [TestMethod]
        public void ContainsAllAlphabets_ShouldReturnTrue_WhenAllLettersArePresent()
        {
            // Arrange
            string input = "The quick brown fox jumps over the lazy dog.";

            // Act
            var result = _service.ContainsAllAlphabets(input);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ContainsAllAlphabets_ShouldReturnFalse_WhenNotAllLettersArePresent()
        {
            // Arrange
            string input = "Hello World!";

            // Act
            var result = _service.ContainsAllAlphabets(input);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ContainsAllAlphabets_ShouldReturnFalse_WhenInputIsEmpty()
        {
            // Arrange
            string input = "";

            // Act
            var result = _service.ContainsAllAlphabets(input);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ContainsAllAlphabets_ShouldReturnFalse_WhenInputIsNull()
        {
            // Arrange
            string input = null;

            // Act
            var result = _service.ContainsAllAlphabets(input);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
