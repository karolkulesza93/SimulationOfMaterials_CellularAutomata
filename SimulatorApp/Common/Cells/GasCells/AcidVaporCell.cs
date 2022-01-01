using SimulatorApp.Application;
using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public class AcidVaporCell : GasCell
{
    public AcidVaporCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.AcidVapor);
        life = Rand.Int(5, 20);
    }

    public override void Update(CellularAutomata automata)
    {
        if (hasBeenUpdated) return;

        DrainLife(automata);

        base.Update(automata);
    }
}
