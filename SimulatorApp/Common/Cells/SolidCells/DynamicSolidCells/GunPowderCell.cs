using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public class GunPowderCell : DynamicSolidCell
{
    public GunPowderCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.GunPowder);
        Flamable = true;
    }
}
