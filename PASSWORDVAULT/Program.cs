using System;
namespace PasswordVault.Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string masterPassword = "Kartik@123";
            int attempts = 0;

            while (attempts < 3)
            {
                Console.Write("Enter master password: ");
                string input = ReadPassword(true);

                if (input == masterPassword)
                {
                    Console.WriteLine("Access granted.\n");
                    RunVault();
                    return;
                }

                attempts++;
                Console.WriteLine($"Incorrect. Attempts left: {3 - attempts}");
            }

            Console.WriteLine(" Access denied.");
        }

        static void RunVault()
        {
            PasswordService vault = new PasswordService();

            while (true)
            {
                Console.WriteLine("\n PASSWORD VAULT MENU");
                Console.WriteLine("1. Add Credential");
                Console.WriteLine("2. View All Credentials");
                Console.WriteLine("3. Delete Credential");
                Console.WriteLine("4. Exit");
                Console.Write("Select option: ");
                string opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        Console.Write("Site: ");
                        string site = Console.ReadLine();
                        Console.Write("Username: ");
                        string user = Console.ReadLine();
                        Console.Write("Password: ");
                        string pass = ReadPassword(true);
                        vault.AddCredential(site, user, pass);
                        break;

                    case "2":
                        vault.ViewAll();
                        break;

                    case "3":
                        Console.Write("Site to delete: ");
                        string delSite = Console.ReadLine();
                        vault.DeleteCredential(delSite);
                        break;

                    case "4":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine(" Invalid option.");
                        break;
                }
            }
        }

        static string ReadPassword(bool showAsterisks = false)
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password[..^1];
                    if (showAsterisks)
                        Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    password += key.KeyChar;
                    if (showAsterisks)
                        Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }
    }
}
