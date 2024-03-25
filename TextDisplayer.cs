public interface ITextDisplayer
{
    void EnterInstructions();
    void FirstInstuctions();
    void StartingPrompt();
}

public class TextDisplayer : ITextDisplayer
{
    public void StartingPrompt()
    {
        Console.WriteLine();
        Console.WriteLine("Welcome to the Settlers of Catan Starting Probabilities Calculator. Press any key to continue");
        Console.ReadKey();
        Console.WriteLine("The board will be displayed like this: ");
        Console.WriteLine("\n\n\n");
    }

    public void FirstInstuctions()
    {
        Console.WriteLine();
        Console.WriteLine("Where each '*' will be replaced with a number that represents the aggregate probability");
        Console.WriteLine("of how many resources will be collected from that spot for every 36 dice rolls.");
        Console.WriteLine("The higher the number, the more net resources you are likely to get from that spot.");
        Console.WriteLine("Just enter in each number corresponding to its spot above. Press any key to continue.");
        Console.ReadKey();
        Console.WriteLine("\n");
    }

    public void EnterInstructions()
    {
        Console.WriteLine("Please enter a number 2 - 12 (not 7) and press enter. If entering the desert, enter 0. If you wish to go back, enter 'back'");
        Console.WriteLine();
    }
}
