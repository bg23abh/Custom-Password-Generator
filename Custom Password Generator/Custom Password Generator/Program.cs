using System;
using System.Text;
class PasswordGenerator
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Custom Password Generator!");
        Console.WriteLine("=========================================");

        while (true)
        {
            try
            {
                // Get password length
                Console.Write("Enter the desired password length (minimum 6): ");
                int length = int.Parse(Console.ReadLine());
                if (length < 6)
                {
                    Console.WriteLine("Password length must be at least 6 characters.");
                    continue;
                }

                // Ask for character types
                Console.WriteLine("Include the following in your password:");
                Console.Write("Uppercase letters? (y/n): ");
                bool includeUppercase = Console.ReadLine().ToLower() == "y";

                Console.Write("Lowercase letters? (y/n): ");
                bool includeLowercase = Console.ReadLine().ToLower() == "y";

                Console.Write("Numbers? (y/n): ");
                bool includeNumbers = Console.ReadLine().ToLower() == "y";

                Console.Write("Special characters (e.g., @, #, $)? (y/n): ");
                bool includeSpecial = Console.ReadLine().ToLower() == "y";

                if (!includeUppercase && !includeLowercase && !includeNumbers && !includeSpecial)
                {
                    Console.WriteLine("You must select at least one character type!");
                    continue;
                }

                // Generate password
                string password = GeneratePassword(length, includeUppercase, includeLowercase, includeNumbers, includeSpecial);
                Console.WriteLine($"Generated Password: {password}");

                // Ask to generate another password
                Console.Write("Generate another password? (y/n): ");
                if (Console.ReadLine().ToLower() != "y")
                {
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
        }

        Console.WriteLine("Thank you for using the Custom Password Generator. Goodbye!");
    }

    static string GeneratePassword(int length, bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSpecial)
    {
        const string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowerChars = "abcdefghijklmnopqrstuvwxyz";
        const string numberChars = "0123456789";
        const string specialChars = "@#$%^&*()-_=+<>?";

        StringBuilder characterPool = new StringBuilder();

        if (includeUppercase) characterPool.Append(upperChars);
        if (includeLowercase) characterPool.Append(lowerChars);
        if (includeNumbers) characterPool.Append(numberChars);
        if (includeSpecial) characterPool.Append(specialChars);

        Random random = new Random();
        StringBuilder password = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            int index = random.Next(characterPool.Length);
            password.Append(characterPool[index]);
        }

        return password.ToString();
    }
}
