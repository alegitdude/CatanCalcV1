public interface IBoardDisplayer
{
    void DisplayCenters(Dictionary<string, int[]> hexCenters, bool withLocale);
    void DisplayDoneProbabilites(GameBoard gameboard);
    void DisplayStarterBoard(Dictionary<string, int[]> hexCenters);
}

public class BoardDisplayer : IBoardDisplayer
{
    public void DisplayStarterBoard(Dictionary<string, int[]> hexCenters)
    {

        foreach (KeyValuePair<string, int[]> center in hexCenters)
        {
            int[] centerSpot = { (center.Value[1] + 12) * 2, (center.Value[2] * -1) + 12 };

            Console.SetCursorPosition(centerSpot[0], centerSpot[1]);
            Console.Write(center.Key);

            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                {
                    Console.SetCursorPosition(centerSpot[0], centerSpot[1] - 2);
                    Console.Write("*");

                }
                if (i == 1)
                {
                    Console.SetCursorPosition(centerSpot[0] + 4, centerSpot[1] - 1);
                    Console.Write("*");

                }
                if (i == 2)
                {
                    Console.SetCursorPosition(centerSpot[0] + 4, centerSpot[1] + 1);
                    Console.Write("*");

                }
                if (i == 3)
                {
                    Console.SetCursorPosition(centerSpot[0], centerSpot[1] + 2);
                    Console.Write("*");

                }
                if (i == 4)
                {
                    Console.SetCursorPosition(centerSpot[0] - 4, centerSpot[1] + 1);
                    Console.Write("*");

                }
                if (i == 5)
                {
                    Console.SetCursorPosition(centerSpot[0] - 4, centerSpot[1] - 1);
                    Console.Write("*");

                }
            }

        }
        Console.WriteLine("\n\n\n\n");


    }

    public void DisplayCenters(Dictionary<string, int[]> hexCenters, bool withLocale)
    {

        var cursorPos = Console.GetCursorPosition();
        foreach (KeyValuePair<string, int[]> center in hexCenters)
        {
            Console.SetCursorPosition((cursorPos.Left + center.Value[1] + 12) * 2, (cursorPos.Top + center.Value[2] * -1) + 8);
            if(withLocale == true)
            {
                Console.Write($"{center.Key}={center.Value[0]}");
            }
            else
            {
                Console.Write($"{center.Value[0]}");
            }
            
        }
        Console.WriteLine();
    }


    public void DisplayDoneProbabilites(GameBoard gameboard)
    {
        var cursorPos = Console.GetCursorPosition();
        foreach (KeyValuePair<Tuple<int, int>, SettlementSpot> spot in gameboard.SettlementSpots)
        {
            Console.SetCursorPosition((cursorPos.Left + spot.Key.Item1 + 12) * 2, (cursorPos.Top + spot.Key.Item2 * -1) + 8);
            Console.Write($"{spot.Value.DiceProbability}");

        }
        Console.WriteLine();
    }
}
