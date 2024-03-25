public interface ISettlementSpot
{
    List<Tuple<int, int>> ConnectedHexes { get; set; }
    Tuple<int, int> Coords { get; init; }
    int DiceProbability { get; set; }
}

public class SettlementSpot : ISettlementSpot
{
    public Tuple<int, int> Coords { get; init; }

    public int DiceProbability { get; set; } = 0;

    public List<Tuple<int, int>> ConnectedHexes { get; set; } = new List<Tuple<int, int>>();
    public SettlementSpot(Tuple<int, int> coords, int addedProbability)
    {
        Coords = coords;
        DiceProbability += addedProbability;
    }
}
