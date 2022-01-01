using SimulatorApp.Application;
using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public class OilCell : LiquidCell
{
    public OilCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Oil);
        Flamable = true;
    }

    public override void Update(CellularAutomata automata)
    {
        SetColor(Colors.OilDependingOnDepth(Y));

        base.Update(automata);
    }
}
