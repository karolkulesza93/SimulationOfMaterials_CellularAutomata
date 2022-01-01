using SimulatorApp.Application;
using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;
public class SmokeCell : GasCell
{
    public SmokeCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Smoke);
        life = Rand.Int(20, 80);
    }

    public override void Update(CellularAutomata automata)
    {
        if (hasBeenUpdated) return;

        DrainLife(automata);

        base.Update(automata);
    }
}
