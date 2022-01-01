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
    public bool Flamable { get; init; }

    protected readonly RectangleShape cell;
    protected bool hasBeenUpdated;
    protected int life;
    protected float xVel;
    protected float yVel;

    public Cell(int x, int y)
    {
        cell = new RectangleShape(new Vector2f(1, 1));
        cell.Position = new Vector2f(x, y);
        xVel = 0;
        yVel = 0;
        hasBeenUpdated = false;
    }

    public void SetPosition(int x, int y) => cell.Position = new Vector2f(x, y);

    public void SetColor(Color color) => cell.FillColor = color;

    public void AddToYVel(float amount)
    {
        if (Math.Abs(amount) + Math.Abs(yVel) > Settings.MaxVelocityV)
        {
            return;
        }
        yVel += amount;
    }

    public void AddToXVel(float amount)
    {
        if (Math.Abs(amount) + Math.Abs(xVel) > Settings.MaxVelocityH)
        {
            return;
        }
        xVel += amount;
    }

    public void SwapWith(Cell toSwap)
    {
        var tmp = cell.Position;
        SetPosition(toSwap.X, toSwap.Y);
        toSwap.cell.Position = tmp;
    }

    public void Prepare()
    {
        hasBeenUpdated = false;
    }

    public virtual void Update(CellularAutomata automata)
    {

    }

    public void Draw(RenderTarget target, RenderStates states) => cell.Draw(target, states);
}
