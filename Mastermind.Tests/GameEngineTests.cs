using Xunit;
using Mastermind.core;

namespace Mastermind.Tests
{
    public class GameEngineTest
    {
        private readonly GameEngine _engine = new GameEngine();

        [Theory]
        // Basic test case
        [InlineData("1234", "1234", "++++")]    // Exact match
        [InlineData("1234", "4321", "----")]    // All digits correct but in wrong positions
        [InlineData("1234", "5678", "    ")]    // No matches
        [InlineData("1234", "1243", "++--")]    // Two exact matches and two correct digits in wrong positions
        [InlineData("1234", "1111", "+   ")]    // One exact match

        // Edge cases
        [InlineData("1122", "1211", "+-- ")]    // First '1' is an exact match, one '1' from guess matches secret[1], and guess[1]='2' matches a '2' in secret
        [InlineData("1111", "1122", "++  ")]    // Two exact matches and two incorrect digits

        // PRD test cases
        [InlineData("1234", "4233", "++- ")]    // Exact match
        public void GenerateHint_ReturnCorrectHint(string secreet, string guess, string expectedHint)
        {
            // Act
            var hint = _engine.GenerateHint(secreet, guess);
            Assert.Equal(expectedHint, hint);
        }

        [Theory]
        [InlineData("1234", true)]
        [InlineData("123", false)]  // Too short
        [InlineData("12345", false)] // Too long
        [InlineData("1237", false)]  // Digit out of range (1-6)
        [InlineData("abcd", false)]  // Non-numeric
        public void IsValidGuess_ValidatesCorrectRangeAndLength(string input, bool expected)
        {
            // Act
            var result = _engine.IsValidGuess(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
