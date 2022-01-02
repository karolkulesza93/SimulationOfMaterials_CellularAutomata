using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public class SteelCell : StaticSolidCell
{
    public SteelCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Steel);
        Digestable = true;
    }
}
