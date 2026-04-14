namespace ConsoleApp;

internal static class Project3
{
    static void Main()
    {
        int waterTotal = 0;
        int waterGoal = 0;
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Daily Water Tracker ---");
            Console.WriteLine("1. Add Water");
            Console.WriteLine("2. Set Water Goal");
            Console.WriteLine("3. View Progress");
            Console.WriteLine("4. Reset Water");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddWater(ref waterTotal);
                    break;

                case "2":
                    SetGoal(ref waterGoal);
                    break;

                case "3":
                    DisplayProgress(waterTotal, waterGoal);
                    break;

                case "4":
                    ResetWater(ref waterTotal);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void AddWater(ref int waterTotal)
    {
        Console.Write("Enter cups of water: ");
        int input;

        if (int.TryParse(Console.ReadLine(), out input) && input > 0)
        {
            waterTotal += input;
            Console.WriteLine("Water added!");
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }

    static void SetGoal(ref int waterGoal)
    {
        Console.Write("Enter daily water goal: ");
        int input;

        if (int.TryParse(Console.ReadLine(), out input) && input > 0)
        {
            waterGoal = input;
            Console.WriteLine("Goal set!");
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }

   static void DisplayProgress(int waterTotal, int waterGoal)
    {
        Console.WriteLine($"\nCurrent Water: {waterTotal} cups");
        Console.WriteLine($"Goal: {waterGoal} cups");

        if (waterGoal > 0)
        {
            int remaining = waterGoal - waterTotal;

            if (remaining > 0)
            {
                Console.WriteLine($"You need {remaining} more cups.");
            }
            else
            {
                Console.WriteLine("Goal reached or exceeded!");
            }
        }
        else
        {
            Console.WriteLine("Set a goal first.");
        }
    }

    static void ResetWater(ref int waterTotal)
    {
        waterTotal = 0;
        Console.WriteLine("Water has been reset.");
    }
}