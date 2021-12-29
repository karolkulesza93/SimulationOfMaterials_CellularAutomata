using SimulatorApp.Application;

namespace SimulatorApp.Common.Cells.SolidCells.DynamicSolidCells;

public class SandCell : DynamicSolidCell
{
    public SandCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Sand);
    }
}
