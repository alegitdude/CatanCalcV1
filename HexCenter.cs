public interface IHexCenter
{
    int CenterNum { get; init; }
    Tuple<int, int> Coordinates { get; init; }
    int DiceProbability { get; init; }
    string Resource { get; init; }
}

public class HexCenter : IHexCenter
{
    public int CenterNum { get; init; }
    public Tuple<int, int> Coordinates { get; init; }
    public int DiceProbability { get; init; }
    public string Resource { get; init; } = "";
    public HexCenter(Tuple<int, int> coords, int centerNum)
    {
        Coordinates = coords;
        CenterNum = centerNum;
        DiceProbability = calculateCenterProbability(centerNum);
    }

    private int calculateCenterProbability(int center)
    {
        int newValue = 0;
        switch (center)
        {
            case 2:
            case 12:
                newValue = 1;
                break;
            case 3:
            case 11:
                newValue = 2;
                break;
            case 4:
            case 10:
                newValue = 3;
                break;
            case 5:
            case 9:
                newValue = 4;
                break;
            case 6:
            case 8:
                newValue = 5;
                break;
            case 0:
                newValue = 0;
                break;
        }

        return newValue;
    }

}
