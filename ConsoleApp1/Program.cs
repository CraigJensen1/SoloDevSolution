using ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            // 1. Display the menu options
            Console.WriteLine("Welcome to the Console Menu App!");
            Console.WriteLine("Please choose a project:");
            Console.WriteLine("1. Project1");
            Console.WriteLine("2. Project2");
            Console.WriteLine("3. Project3");
            Console.WriteLine("4. Project4");
            Console.WriteLine("5. Astrid");
            Console.WriteLine("E. Exit");
            Console.Write("Enter your choice: ");

            // 2. Get user input
            string choice = Console.ReadLine();

            // 3. Process the user's choice using a switch statement
            switch (choice.ToLower())
            {
                case "1":
                    Project1.Run();
                    break;
                case "2":
                    Project2.Run();
                    break;
                case "3":
                    Project3.Run();
                    break;
                case "4":
                    Project4.Run();
                    break;
                case "5":
                    Project5.Run();
                    break;
                case "e":
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to return to the menu.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
