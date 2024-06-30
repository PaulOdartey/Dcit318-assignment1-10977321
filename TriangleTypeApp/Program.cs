using System;

namespace TriangleTypeApp
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            DisplayWelcomeMessage();

            ProcessTriangles();
            DisplayExitMessage();
        }

        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Triangle Type Identifier!");
            Console.WriteLine("Enter the lengths of three sides of a triangle to determine its type.");
            Console.WriteLine("Type 'exit' at any prompt to quit the application.");
            Console.WriteLine();
        }

        static void ProcessTriangles()
        {
            while (true)
            {
                double[] sides = GetTriangleSides();
                if (sides == null) break;

                if (IsValidTriangle(sides))
                {
                    string triangleType = DetermineTriangleType(sides);
                    DisplayTriangleType(triangleType);
                    DisplayFunFact(triangleType);
                }
                else
                {
                    Console.WriteLine("These side lengths cannot form a valid triangle.");
                }

                Console.WriteLine();
            }
        }

        static double[] GetTriangleSides()
        {
            double[] sides = new double[3];
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Enter the length of side {i + 1} or type 'exit' to quit: ");
                string input = Console.ReadLine() ?? string.Empty;
                if (input.ToLower() == "exit") return null;

                if (!double.TryParse(input, out sides[i]) || sides[i] <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive number.");
                    i--;
                }
            }
            return sides;
        }

        static bool IsValidTriangle(double[] sides)
        {
            return sides[0] + sides[1] > sides[2] &&
                   sides[1] + sides[2] > sides[0] &&
                   sides[2] + sides[0] > sides[1];
        }

        static string DetermineTriangleType(double[] sides)
        {
            if (sides[0] == sides[1] && sides[1] == sides[2])
                return "Equilateral";
            else if (sides[0] == sides[1] || sides[1] == sides[2] || sides[2] == sides[0])
                return "Isosceles";
            else
                return "Scalene";
        }

        static void DisplayTriangleType(string triangleType)
        {
            Console.WriteLine($"The triangle is {triangleType}.");
        }

        static void DisplayFunFact(string triangleType)
        {
            string[] facts = {
                "Equilateral: All three sides are equal and all angles are 60 degrees.",
                "Isosceles: Two sides are equal, and the angles opposite these sides are also equal.",
                "Scalene: All sides have different lengths and all angles are different."
            };

            string fact = triangleType switch
            {
                "Equilateral" => facts[0],
                "Isosceles" => facts[1],
                "Scalene" => facts[2],
                _ => "No fun fact available for this triangle type."
            };

            Console.WriteLine("Fun Fact: " + fact);
        }

        static void DisplayExitMessage()
        {
            Console.WriteLine("Thank you for using the Triangle Type Identifier. Goodbye!");
        }
    }
}