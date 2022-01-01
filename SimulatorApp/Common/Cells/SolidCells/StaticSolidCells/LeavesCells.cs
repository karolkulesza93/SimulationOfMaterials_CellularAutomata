using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public class LeavesCells : StaticSolidCell
{
    public LeavesCells(int x, int y) : base(x, y)
    {
        SetColor(Colors.Leaves);
    }

    public override void Heat()
    {
        // TODO
    }
}
