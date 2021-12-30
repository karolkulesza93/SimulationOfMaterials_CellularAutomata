using SFML.Graphics;
using SFML.System;
using SimulatorApp.Application;

namespace SimulatorApp.Common.Cells;

public abstract class Cell : Drawable
{
    public int X
    {
        get => (int)cell.Position.X;
    }
    public int Y
    {
        get => (int)cell.Position.Y;
    }

    protected readonly RectangleShape cell;
    protected int life;
    protected float hVel;
    protected float vVel;

    public Cell(int x, int y)
    {
        cell = new RectangleShape(new Vector2f(1, 1));
        cell.Position = new Vector2f(x, y);
        hVel = 0;
        vVel = 0;
    }

    public void SetPosition(int x, int y) => cell.Position = new Vector2f(x, y);

    public void SetColor(Color color) => cell.FillColor = color;

    public void AddToVVel(float amount)
    {
        if (Math.Abs(amount) + Math.Abs(vVel) > Settings.MaxVelocityV)
        {
            return;
        }
        vVel += amount;
    }

    public void AddToHVel(float amount)
    {
        if (Math.Abs(amount) + Math.Abs(hVel) > Settings.MaxVelocityH)
        {
            return;
        }
        hVel += amount;
    }

    public void SwapWith(Cell toSwap)
    {
        var tmp = cell.Position;
        SetPosition(toSwap.X, toSwap.Y);
        toSwap.cell.Position = tmp;
    }

    public virtual void Update(CellularAutomata automata)
    {

    }

    public void Draw(RenderTarget target, RenderStates states) => cell.Draw(target, states);
}
