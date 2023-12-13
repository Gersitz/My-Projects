namespace GameApp;

internal class Program
{
    static void Main(string[] args)
    {
        Intro();
        GameSelect();
    }



    private static void Intro()
    {
        Console.WriteLine("Welcome to the Game Hub!");
        Console.WriteLine("Please select one of the available games.");
        Console.WriteLine("The library will be continually expanded, so check back sometimes to see what's new!");
    }

    private static void AvailableGames()
    {
        Console.WriteLine("\nAvailable Games:");
        Console.WriteLine("1. Guess The Number");
    }
    private static void GameSelect()
    {
        bool repeat;
        AvailableGames();
        Console.WriteLine("\nPlease enter the number of the game you want to play.");
        do
        {
            if (int.TryParse(Console.ReadLine(), out int selectedGame))
            {
                switch (selectedGame)
                {
                    case 1:
                        GuessTheNumber guessTheNumber = new GuessTheNumber();
                        guessTheNumber.SetupNumberGame();
                        guessTheNumber.StartGame();
                        break;
                }
            }
        } while (repeat = true);
    }
}
