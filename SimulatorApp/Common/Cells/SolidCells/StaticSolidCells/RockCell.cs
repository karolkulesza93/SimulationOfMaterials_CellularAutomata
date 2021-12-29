namespace SimulatorApp.Common.Cells.SolidCells.StaticSolidCells;

public class RockCell : StaticSolidCell
{
    public RockCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Rock);
    }
}
