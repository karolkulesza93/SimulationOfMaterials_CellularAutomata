using SimulatorApp.Application;
using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public class FlameCell : GasCell
{
    public FlameCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Flame);
        life = Rand.Int(5, 15);
    }

    public override void Update(CellularAutomata automata)
    {
        if (hasBeenUpdated) return;

        DrainLife(automata);

        base.Update(automata);
    }
}
