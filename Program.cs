using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

RunGame();

void RunGame()
{
    Dictionary<string, int[]> hexCenters = new Dictionary<string, int[]> {
    {"A1", new int[] {0, -4, 6 } },
    {"A2", new int[] {0, 0, 6 } },
    {"A3", new int[] {0, 4, 6 } },
    {"B1", new int[] {0, -6, 3 } },
    {"B2", new int[] {0, -2, 3 } },
    {"B3", new int[] {0, 2, 3 } },
    {"B4", new int[] {0, 6, 3 } },
    {"C1", new int[] {0, -8, 0 } },
    {"C2", new int[] {0, -4, 0 } },
    {"C3", new int[] {0, 0, 0 } },
    {"C4", new int[] {0, 4, 0 } },
    {"C5", new int[] {0, 8, 0 } },
    {"D1", new int[] {0, -6, -3 } },
    {"D2",new int[] {0, -2, -3 } },
    {"D3", new int[] {0, 2, -3 } },
    {"D4", new int[] {0, 6, -3 } },
    {"E1", new int[] {0, -4, -6 } },
    {"E2", new int[] {0, 0, -6 } },
    {"E3", new int[] {0, 4, -6 } },

    };


    IBoardDisplayer boardDisplayer = new BoardDisplayer();
    ITextDisplayer textDisplayer = new TextDisplayer();

    textDisplayer.StartingPrompt();

    boardDisplayer.DisplayStarterBoard(hexCenters);

    textDisplayer.FirstInstuctions();

    string[] allCenters = hexCenters.Keys.ToArray();

    for (int i = 0; i < allCenters.Length; i++)
    {
        textDisplayer.EnterInstructions();
        Console.WriteLine($"What does {allCenters[i]} = ? ");
        var submission = Console.ReadLine();
        if (submission == null)
        {
            i = i - 1;
            continue;
        }
        submission = submission.Trim();

        if (submission == "back")
        {
            if (i == 0)
            {
                i = -1;
                continue;
            }
            i = i - 2;
            continue;
        }
        if (hexNumSubmissionValidator(submission) == false)
        {
            i = i - 1;
            continue;
        }
        hexCenters[allCenters[i]][0] = int.Parse(submission);
    }

    boardDisplayer.DisplayCenters(hexCenters, false);

    string response = "";
    for (int i = 0; i < 1; i++)
    {
        Console.WriteLine();
        Console.WriteLine("Do all spots look correct? If yes enter 'correct', if not, enter 'wrong'");
        response = Console.ReadLine();
        if (response == "correct" || response == "wrong")
        {
            break;
        }
        else
        {
            i = i - 1; continue;
        }

    }
    ////// Editing Mode /////////
    if (response == "wrong")
    {
        bool doneCorrecting = false;
        Console.WriteLine("Please enter the location of the incorrect number:");
        boardDisplayer.DisplayCenters(hexCenters, true);
        while (doneCorrecting == false)
        {

            Console.WriteLine("Location examples include A1, B3 etc..");
            string correctionSpot = "";
            correctionSpot = Console.ReadLine().Trim();

            ///// Handle edit input /////////
            if (allCenters.Contains(correctionSpot) == false)
            {
                continue;
            }
            if (allCenters.Contains(correctionSpot) == true)
            {
                bool doneEditing = false;
                while (doneEditing == false)
                {
                    Console.WriteLine($"What do you want to change {correctionSpot} to be?");
                    string newSubmission = Console.ReadLine();
                    if (hexNumSubmissionValidator(newSubmission) == false)
                    {
                        continue;
                    }
                    if (hexNumSubmissionValidator(newSubmission) == true)
                    {
                        hexCenters[correctionSpot][0] = int.Parse(newSubmission);
                        Console.WriteLine("");
                        boardDisplayer.DisplayCenters(hexCenters, true);
                        Console.WriteLine("Do you want to edit another space?");

                        bool stillEditting = true;
                        while (stillEditting == true)
                        {
                            Console.WriteLine("Please enter 'yes' or 'no'");
                            string aSub = Console.ReadLine().Trim();

                            if (aSub != "yes" && aSub != "no")
                            {
                                continue;
                            }
                            stillEditting = false;
                            doneEditing = true;
                            if (aSub == "yes")
                            {
                                break;
                            }
                            if (aSub == "no")
                            {
                                doneCorrecting = true;
                                break;
                            }
                        }

                    }
                }
            }

        }
    }
    ////// Exit Editing Mode /////////
    ///
    Console.WriteLine();
    Console.WriteLine("Here is your completed board");
    boardDisplayer.DisplayCenters(hexCenters, false);
    Console.WriteLine();
    GameBoard gameboard = new GameBoard(hexCenters);
    Console.WriteLine();
    Console.WriteLine("Here are your probabilites for each settlement spot:");
    Console.WriteLine();
    boardDisplayer.DisplayDoneProbabilites(gameboard);
    Console.ReadLine();





    bool hexNumSubmissionValidator(string sub)
    {
        int numSub = 0;

        if (string.IsNullOrWhiteSpace(sub))
        {
            return false;
        }
        try
        {
            numSub = int.Parse(sub);
        }
        catch (FormatException ex)
        {
            return false;
        }
        if (numSub == 7)
        {
            return false;
        }
        if (numSub == 0)
        {
            return true;
        }
        if (numSub <= 12 && numSub >= 2)
        {
            return true;
        }
        return false;


    }


}
