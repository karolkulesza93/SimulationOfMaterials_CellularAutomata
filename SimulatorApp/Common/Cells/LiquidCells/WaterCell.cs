using SimulatorApp.Application;
using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public class WaterCell : LiquidCell
{
    public WaterCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Water);
    }

    public override void Update(CellularAutomata automata)
    {
        SetColor(Colors.WaterDependingOnDepth(Y));
        base.Update(automata);
    }
}
