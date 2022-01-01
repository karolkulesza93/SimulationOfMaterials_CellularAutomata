using SimulatorApp.Application;
using SimulatorApp.Common.Utils;

namespace SimulatorApp.Common.Cells;

public class FireCell : DynamicSolidCell
{
    public FireCell(int x, int y) : base(x, y)
    {
        SetColor(Colors.Fire);
        life = Rand.Int(20, 100);
    }

    public override void Update(CellularAutomata automata)
    {
        if (hasBeenUpdated) return;

        SetColor(Colors.Fire);
        life--;
        if (life <= 0)
        {
            automata.Cells[X, Y] = new AirCell(X, Y);
            return;
        }

        Cell c;

        // ignite
        for (int y = Y - 1; y <= Y + 1; y++)
        {
            for (int x = X - 1; x <= X + 1; x++)
            {
                c = automata.GetCell(x, y);
                if (c != null && c.Flamable)
                {
                    var lightUp = Rand.Probability(1);
                    if (lightUp)
                    {
                        automata.Cells[x, y] = new FireCell(x, y);
                    }
                }
            }
        }

        // flame and smoke
        var produce = Rand.Probability(3);
        if (produce)
        {
            c = automata.GetCell(X, Y - 1);
            if (c != null && c.GetType() == typeof(AirCell))
            {
                var dec = Rand.Bool();
                if (dec)
                {
                    automata.Cells[X, Y] = new FlameCell(X, Y);
                }
                else
                {
                    automata.Cells[X, Y] = new SmokeCell(X, Y);
                }
            }
        }

        base.Update(automata);
    }
}
