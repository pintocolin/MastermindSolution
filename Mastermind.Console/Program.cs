using Mastermind.Core;

namespace Mastermind.ConsoleApp
{
    internal class Program
    {
        private const int MaxAttempts = 10;
        private const int CodeLength = 4;

        static void Main(string[] args)
        {
            var engine = new GameEngine();
            string secretCode = GenerateSecretCode();

            Console.WriteLine("******************************** Mastermind ******************************** ");
            Console.WriteLine($"A {CodeLength}-digit code (1-6) has been generated.");
            Console.WriteLine($"You have {MaxAttempts} attempts to crack it.");
            Console.WriteLine("Hints: [+] correct position, [-] correct digit only incorrect position.");
            Console.WriteLine("****************************************************************************\n");

            // Game Loop
            for (int attempt = 1; attempt <= MaxAttempts; attempt++)
            {
                Console.Write($"Attempt {attempt}/{MaxAttempts}: ");
                string? input = Console.ReadLine();

                if (!engine.IsValidGuess(input))
                {
                    Console.WriteLine("Invalid! Enter 4 digits between 1 and 6.");
                    attempt--; // Do not count invalid attempts
                    continue;
                }

                string hint = engine.GenerateHint(secretCode, input!);

                if (hint == "++++")
                {
                    Console.WriteLine("\nCongratulations! You solved it!");
                    return;
                }

                Console.WriteLine($"Result: {hint}");
            }

            Console.WriteLine("\nGame Over.");
            Console.WriteLine($"The secret code was: {secretCode}");
        }

        /// <summary>
        /// Generates a random 4-digit code where each digit is between 1 and 6.
        /// </summary>
        private static string GenerateSecretCode()
        {
            var random = new Random();
            var code = new char[CodeLength];
            for (int i = 0; i < CodeLength; i++)
            {
                // Next(1, 7) gives values 1 through 6
                code[i] = (char)('0' + random.Next(1, 7));
            }
            return new string(code);
        }
    }
}