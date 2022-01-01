using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public class WoodCell : StaticSolidCell
{
    public WoodCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Wood);
    }

    public override void Heat()
    {
        // TODO
    }
}
