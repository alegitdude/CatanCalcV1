public interface IGameBoard
{
    Dictionary<Tuple<int, int>, IHexCenter> HexCenters { get; init; }
    Dictionary<Tuple<int, int>, SettlementSpot> SettlementSpots { get; set; }

    Dictionary<Tuple<int, int>, IHexCenter> createHexCenters(Dictionary<string, int[]> hexCenters);
}

public class GameBoard : IGameBoard
{
    public Dictionary<Tuple<int, int>, IHexCenter> HexCenters { get; init; }
    public Dictionary<Tuple<int, int>, SettlementSpot> SettlementSpots { get; set; }
    public GameBoard(Dictionary<string, int[]> hexCenters)
    {
        HexCenters = createHexCenters(hexCenters);
        SettlementSpots = createSettlementSpots(HexCenters);
    }

    public Dictionary<Tuple<int, int>, IHexCenter> createHexCenters(Dictionary<string, int[]> hexCenters)
    {
        Dictionary<Tuple<int, int>, IHexCenter> finishedHexCenters = new Dictionary<Tuple<int, int>, IHexCenter>();

        foreach (KeyValuePair<string, int[]> center in hexCenters)
        {
            Tuple<int, int> coords = new Tuple<int, int>(center.Value[1], center.Value[2]);
            IHexCenter newHex = new HexCenter(coords, center.Value[0]);
            finishedHexCenters.Add(coords, newHex);
        }

        return finishedHexCenters;
    }

    private Dictionary<Tuple<int, int>, SettlementSpot> createSettlementSpots(Dictionary<Tuple<int, int>, IHexCenter> centers)
    {
        Dictionary<Tuple<int, int>, SettlementSpot> settleSpots = new Dictionary<Tuple<int, int>, SettlementSpot>();

        foreach (KeyValuePair<Tuple<int, int>, IHexCenter> center in centers) //
        {
            Tuple<int, int>[] points = createHexPointCoords(center.Key);
            foreach (Tuple<int, int> point in points)
            {

                if (settleSpots.ContainsKey(point))
                {
                    Tuple<int, int> aCenter = new Tuple<int, int>(center.Key.Item1, center.Key.Item2);
                    settleSpots[point].DiceProbability = settleSpots[point].DiceProbability + HexCenters[aCenter].DiceProbability;
                }
                else
                {
                    SettlementSpot aNewSpot = new SettlementSpot(point, center.Value.DiceProbability);
                    settleSpots.Add(point, aNewSpot);

                }
            }
        }

        return settleSpots;
    }



    Tuple<int, int>[] createHexPointCoords(Tuple<int, int> center)
    {
        Tuple<int, int>[] hexPointCoords = new Tuple<int, int>[6];

        for (int i = 0; i < 6; i++)
        {
            if (i == 0)
            {
                Tuple<int, int> xY = new Tuple<int, int>(center.Item1, center.Item2 + 2);
                hexPointCoords[i] = xY;
                continue;
            }
            if (i == 1)
            {
                Tuple<int, int> xY = new Tuple<int, int>(center.Item1 + 2, center.Item2 + 1);
                hexPointCoords[i] = xY;
                continue;
            }
            if (i == 2)
            {
                Tuple<int, int> xY = new Tuple<int, int>(center.Item1 + 2, center.Item2 - 1);
                hexPointCoords[i] = xY;
                continue;
            }
            if (i == 3)
            {
                Tuple<int, int> xY = new Tuple<int, int>(center.Item1, center.Item2 - 2);
                hexPointCoords[i] = xY;
                continue;
            }
            if (i == 4)
            {
                Tuple<int, int> xY = new Tuple<int, int>(center.Item1 - 2, center.Item2 - 1);
                hexPointCoords[i] = xY;
                continue;
            }
            if (i == 5)
            {
                Tuple<int, int> xY = new Tuple<int, int>(center.Item1 - 2, center.Item2 + 1);
                hexPointCoords[i] = xY;
                continue;
            }

        }

        return hexPointCoords;
    }


}