var lb = new Library.Library();
var hangman = new Hangman.Hangman();

bool isRunning = true;

static void InputType(int input, int color, string informationSentence)
{
    switch (color)
    {
        case 1:
            Console.Write($"{input}.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" {informationSentence}");
            Console.ResetColor();
            break;
        case 2:
            Console.Write($"{input}.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($" {informationSentence}");
            Console.ResetColor();
            break;
        case 3:
            Console.Write($"{input}.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" {informationSentence}");
            Console.ResetColor();
            break;
        default:
            Console.WriteLine("Something went wrong.");
            return;
    }
    return;
}

while (isRunning)
{
    Console.Clear();
    Console.WriteLine("======================================");
    Console.WriteLine("            Select a option           ");
    Console.WriteLine("======================================");
    Console.WriteLine();

    // A guide to show, and tell what the list is containing.
    Console.WriteLine($"Color guide.");
    Console.BackgroundColor = ConsoleColor.Green;
    Console.Write("  ");
    Console.ResetColor();
    Console.WriteLine(" This is a done projekt.");
    Console.BackgroundColor = ConsoleColor.Yellow;
    Console.Write("  ");
    Console.ResetColor();
    Console.WriteLine(" This is work in progress.");
    Console.BackgroundColor = ConsoleColor.Red;
    Console.Write("  ");
    Console.ResetColor();
    Console.WriteLine(" This is not currently working.");
    Console.WriteLine("\n\nSelect a option:");


    // 1 = done
    // 2 = work in progress
    // 3 = placeholder

    InputType(1, 2, "Library");
    InputType(2, 1, "Hangman");
    Console.WriteLine("9. Exit");



    Console.Write("\n > ");

    string? input = Console.ReadLine();
    
    if (!int.TryParse(input, out int choice))
    {
        Console.WriteLine($"Invalid choice. Press a key to try again");
        Console.ReadLine();
        continue;
    }

    switch (choice)
    {
        case 1:
            lb.Start();
            break;
        case 2:
            hangman.Start();
            break;
        case 9:
            Console.WriteLine("\nBye, thanks for trying my code.");
            return;
        default:
            Console.WriteLine("Enter a number between 1 and 9.");
            Console.ReadKey();
            break;
    }
}