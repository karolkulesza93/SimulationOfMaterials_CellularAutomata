namespace SimulatorApp.Common.Cells;

public class RockCell : StaticSolidCell
{
    public RockCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Rock);
    }
}
