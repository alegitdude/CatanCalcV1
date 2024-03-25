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
		return center switch
		{
			1 => 1,
			12 => 1,
			3 => 2,
			11 => 2,
			4 => 3,
			10 => 3,
			5 => 4,
			9 => 4,
			6 => 5,
			8 => 5,
			0 => 0,
			_ => throw new ArgumentOutOfRangeException(nameof(center), $"The int value for {nameof(center)}: {center} is invalid"),
		};
	}
}
