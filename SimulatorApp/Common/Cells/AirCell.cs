using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public class AirCell : Cell
{
    public AirCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Air);
    }
}
