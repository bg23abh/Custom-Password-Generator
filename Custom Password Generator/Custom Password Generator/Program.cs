using System;
using System.Text;

class PasswordGenerator
{
    static void Main()
    {
        Console.WriteLine("Password Generator");

        Console.Write("Enter password length (min 6): ");
        int length = int.Parse(Console.ReadLine());
        if (length < 6)
        {
            Console.WriteLine("Length must be at least 6!");
            return;
        }

        Console.Write("Include uppercase? (y/n): ");
        bool upper = Console.ReadLine().ToLower() == "y";

        Console.Write("Include lowercase? (y/n): ");
        bool lower = Console.ReadLine().ToLower() == "y";

        Console.Write("Include numbers? (y/n): ");
        bool numbers = Console.ReadLine().ToLower() == "y";

        Console.Write("Include special characters? (y/n): ");
        bool special = Console.ReadLine().ToLower() == "y";

        if (!upper && !lower && !numbers && !special)
        {
            Console.WriteLine("You must select at least one character type!");
            return;
        }

        string password = GeneratePassword(length, upper, lower, numbers, special);
        Console.WriteLine($"Generated Password: {password}");
    }

    static string GeneratePassword(int length, bool upper, bool lower, bool numbers, bool special)
    {
        string chars = "";
        if (upper) chars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        if (lower) chars += "abcdefghijklmnopqrstuvwxyz";
        if (numbers) chars += "0123456789";
        if (special) chars += "@#$%^&*()-_=+<>?";

        Random random = new Random();
        StringBuilder password = new StringBuilder();
        for (int i = 0; i < length; i++)
            password.Append(chars[random.Next(chars.Length)]);

        return password.ToString();
    }
}
