using System.Linq;

namespace Mastermind.Core
{
    public class GameEngine
    {
        string hint = string.Empty;

        /// <summary>
        /// 1. Generates the hint string (+ for correct positon and value, - for correct value only).
        /// 2. Pluses are always printed first.
        /// </summary>
        public string GenerateHint(string secret, string guess)
        {
            // Logic to generate hint based on secret and guess

            int pluses = 0;
            int minuses = 0;

            // Track which positions have already been matched to prevent double-counting
            bool[] secretMatched = new bool[4];
            bool[] guessMatched = new bool[4];

            // PASS 1: Check for Pluses (+)
            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == secret[i])
                {
                    pluses++;
                    secretMatched[i] = true;
                    guessMatched[i] = true;
                }
            }

            // PASS 2: Check for Minuses (-)
            for (int i = 0; i < 4; i++)
            {
                if (guessMatched[i]) continue; // Skip if this digit was already a Plus

                for (int j = 0; j < 4; j++)
                {
                    if (!secretMatched[j] && guess[i] == secret[j])
                    {
                        minuses++;
                        secretMatched[j] = true; // Mark this secret digit as used
                        break; // Move to the next digit in the guess
                    }
                }
            }

            // Pad with spaces to always return a 4-character hint
            int totalFeedback = pluses + minuses;
            int spaces = 4 - totalFeedback;
            return new string('+', pluses) + new string('-', minuses) + new string(' ', spaces);
        }

        /// <summary>
        /// 1. Validates that the input is exactly 4 digits.
        /// 2. Each digit is between 1 and 6.
        /// </summary>
        public bool IsValidGuess(string input)
        {
            // Logic to validate the guess
            if (string.IsNullOrWhiteSpace(input) || input.Length != 4)
            {
                return false;
            }

            // Check if every character is a digit between '1' and '6'
            return input.All(c => c >= '1' && c <= '6');
        }
    }
}
