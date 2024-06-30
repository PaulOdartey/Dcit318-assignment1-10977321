using System;

namespace GradeCalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayWelcomeMessage();
            RunGradeCalculator();
            DisplayExitMessage();
        }

        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the DCIT 318 Grade Calculator!");
            Console.WriteLine("You can enter your grade (0-100) to see the letter grade.");
            Console.WriteLine("Type 'exit' to quit the application.");
            Console.WriteLine();
        }

        static void RunGradeCalculator()
        {
            while (true)
            {
                string input = GetUserInput();
                if (input.ToLower() == "exit")
                    break;


                if (TryParseGrade(input, out int grade))
                    DisplayLetterGrade(grade);
                else
                    DisplayInvalidInputMessage();

                Console.WriteLine();
            }
        }

        static string GetUserInput()
        {
            Console.Write("Enter your grade (0-100) or type 'exit' to quit: ");
            return Console.ReadLine();
        }

        static bool TryParseGrade(string input, out int grade)
        {
            return int.TryParse(input, out grade) && grade >= 0 && grade <= 100;
        }

        static void DisplayLetterGrade(int grade)
        {
            string letterGrade = CalculateLetterGrade(grade);
            Console.WriteLine($"Your grade is {letterGrade}.");
        }

        static string CalculateLetterGrade(int grade)

        {
            if (grade >= 90) return "A";
            if (grade >= 80) return "B";
            if (grade >= 70) return "C";
            if (grade >= 60) return "D";
            return "F";
        }

        static void DisplayInvalidInputMessage()
        {
            Console.WriteLine("Invalid input. Please enter a valid grade or type 'exit' to quit.");
        }

        static void DisplayExitMessage()
        {
            Console.WriteLine("Thank you for using the DCIT 318 Grade Calculator. Goodbye!");
        }
    }
}

