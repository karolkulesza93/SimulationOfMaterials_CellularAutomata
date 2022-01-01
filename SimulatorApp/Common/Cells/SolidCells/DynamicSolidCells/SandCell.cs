using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public class SandCell : DynamicSolidCell
{
    public SandCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Sand);
    }
}
