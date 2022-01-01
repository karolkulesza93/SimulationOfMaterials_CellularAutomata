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

        life--;
        if (life <= 0)
        {
            automata.Cells[X, Y] = new AirCell(X, Y);
            return;
        }

        base.Update(automata);
    }
}
