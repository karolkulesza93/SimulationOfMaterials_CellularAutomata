using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public class LeavesCell : StaticSolidCell
{
    public LeavesCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Leaves);
        Flamable = true;
    }
}
