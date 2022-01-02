using SimulatorApp.Application;
using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public class SteelCell : StaticSolidCell
{
    private bool rusted;

    public SteelCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Steel);
        Digestable = true;
        rusted = false;
    }

    public void Corrode(CellularAutomata automata)
    {
        var corrode = Rand.Probability(0.01f);
        if (corrode && WaterOrRustAround(automata))
        {
            rusted = true;
            SetColor(Colors.Rust);
        }
    }

    public bool WaterOrRustAround(CellularAutomata automata)
    {
        for (int y = Y - 1; y <= Y + 1; y++)
        {
            for (int x = X - 1; x <= X + 1; x++)
            {
                if (x == X && y == Y) continue;

                Cell c = automata.GetCell(x, y);
                if (c != null && c.GetType().IsSubclassOf(typeof(LiquidCell)))
                {
                    return true;

                }
                if (c != null && c.GetType() == typeof(SteelCell))
                {
                    if (((SteelCell)c).rusted)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public override void Update(CellularAutomata automata)
    {
        if (hasBeenUpdated) return;

        Corrode(automata);

        base.Update(automata);
    }
}
