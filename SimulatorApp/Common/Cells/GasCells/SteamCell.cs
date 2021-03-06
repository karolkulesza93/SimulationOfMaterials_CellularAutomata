using SimulatorApp.Application;
using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public class SteamCell : GasCell
{
    public SteamCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Steam);
        life = Rand.Int(30, 80);
    }

    public override void Update(CellularAutomata automata)
    {
        if (hasBeenUpdated) return;

        DrainLife(automata);

        base.Update(automata);
    }
}
