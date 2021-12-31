using SFML.Graphics;
using SimulatorApp.Common;
using SimulatorApp.Common.Cells;

namespace SimulatorApp.Application;

public class CellularAutomata : Drawable
{
    public Cell[,] Cells { get; init; }

    private bool dir;

    public CellularAutomata()
    {
        dir = true;
        Cells = new Cell[Settings.X, Settings.Y];

        for (int y = 0; y < Cells.GetUpperBound(1); y++)
        {
            for (int x = 0; x < Cells.GetUpperBound(0); x++)
            {
                Cells[x, y] = new AirCell(x, y);
            }
        }
    }

    public void Update()
    {
        for (int y = Cells.GetUpperBound(1) - 1; y >= 0; y--)
        {
            if (dir)
            {
                for (int x = 0; x < Cells.GetUpperBound(0); x++)
                {
                    SingleUpdateOperation(x, y);
                }
            }
            else
            {
                for (int x = Cells.GetUpperBound(0) - 1; x >= 0; x--)
                {
                    SingleUpdateOperation(x, y);
                }
            }
        }
        dir = !dir;
    }

    public void Reinitialize()
    {
        for (int y = 0; y < Cells.GetUpperBound(1); y++)
        {
            for (int x = 0; x < Cells.GetUpperBound(0); x++)
            {
                Cells[x, y] = new AirCell(x, y);
            }
        }
    }

    private void SingleUpdateOperation(int x, int y)
    {
        var type = Cells[x, y].GetType();
        if (type == typeof(AirCell) || type.IsSubclassOf(typeof(StaticSolidCell)))
        {
            return;
        }
        Cells[x, y].Update(this);
    }

    public void Draw(RenderTarget target, RenderStates states)
    {
        for (int y = 0; y < Cells.GetUpperBound(1); y++)
        {
            for (int x = 0; x < Cells.GetUpperBound(0); x++)
            {
                Cells[x, y].Draw(target, states);
                Cells[x, y].Prepare();
            }
        }
    }

    public Cell GetCell(int x, int y)
    {
        try
        {
            return Cells[x, y];
        }
        catch
        {
            return null;
        }
    }

    public void DestroyCell(int x, int y)
    {
        try
        {
            Cells[x, y] = new AirCell(x, y);
        }
        catch { }
    }

    public void SwapCells(int ax, int ay, int bx, int by)
    {
        Cell tmp = Cells[ax, ay];
        Cells[ax, ay] = Cells[bx, by];
        Cells[bx, by] = tmp;

        Cells[ax, ay].SwapWith(Cells[bx, by]);
    }

    public void SetAreaAs(Type type, int xMouse, int yMouse, int radius = 5, float density = 0.3f)
    {
        xMouse /= Settings.Scale;
        yMouse /= Settings.Scale;

        var howMany = Math.PI * Math.Pow(radius, 2) * density;

        for (int i = 0; i < howMany; i++)
        {
            int x = xMouse + Rand.Int(-radius, radius);
            int y = yMouse + Rand.Int(-radius, radius);

            if (x < 0 || x > Settings.X - 1 || y < 0 || y > Settings.Y - 1)
            {
                continue;
            }

            var cell = Cells[x, y];
            if (cell != null && radius >= Math.Sqrt(Math.Pow(x - xMouse, 2) + Math.Pow(y - yMouse, 2)))
            {
                switch (type.Name)
                {
                    case nameof(SandCell): Cells[x, y] = new SandCell(x, y); break;
                    case nameof(WaterCell): Cells[x, y] = new WaterCell(x, y); break;
                    case nameof(RockCell): Cells[x, y] = new RockCell(x, y); break;
                }
            }
        }
    }
}
