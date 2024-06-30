using System;

namespace TicketPriceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayWelcomeMessage();
            ProcessTicketPrices();
            DisplayExitMessage();
        }

        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the DCIT 318 Ticket Price Calculator!");
            Console.WriteLine("You can enter your age to see the ticket price.");
            Console.WriteLine("Type 'exit' to quit the application.");
            Console.WriteLine();
        }

        static void ProcessTicketPrices()
        {
            while (true)
            {
                string input = GetUserInput();

                if (input.ToLower() == "exit")
                    break;

                if (TryParseAge(input, out int age))
                    DisplayTicketPrice(CalculateTicketPrice(age));
                else
                    DisplayInvalidInputMessage();

                Console.WriteLine();
            }
        }

        static string GetUserInput()
        {
            Console.Write("Enter your age or type 'exit' to quit: ");
            return Console.ReadLine();
        }

        static bool TryParseAge(string input, out int age)
        {
            return int.TryParse(input, out age) && age >= 0;
        }

        static int CalculateTicketPrice(int age)
        {
            return (age <= 12 || age >= 65) ? 7 : 10;
        }

        static void DisplayTicketPrice(int price)
        {

            Console.WriteLine($"Your ticket price is GHC{price}.");
        }

        static void DisplayInvalidInputMessage()
        {
            Console.WriteLine("Invalid input. Please enter a valid age or type 'exit' to quit.");
        }

        static void DisplayExitMessage()
        {
            Console.WriteLine("Thank you for using the DCIT 318 Ticket Price Calculator. Goodbye!");
        }
    }
}
