using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SimulatorApp.Common.Cells;

namespace SimulatorApp.Application;

public class InputHandler
{
    private readonly CellularAutomata automata;
    private readonly AutomataGenerator automataGenerator;
    private readonly RenderWindow window;
    private Type currentType;
    private Vector2i previousPos;

    public InputHandler(RenderWindow window, CellularAutomata automata)
    {
        this.automata = automata;
        this.window = window;
        this.automataGenerator = new AutomataGenerator(this.automata);
        previousPos = new Vector2i(-1, -1);
        currentType = typeof(AirCell);
    }

    public void HandleMouseClick(Mouse.Button button, int xPos, int yPos)
    {
        switch (button)
        {
            case Mouse.Button.Left:
                automata.SetAreaRandomlyAs(currentType, xPos, yPos, 2, 1f);
                break;
            case Mouse.Button.Right:
                automata.SetAreaRandomlyAs(currentType, xPos, yPos, 4, 5f);
                break;
            case Mouse.Button.Middle:
                automata.SetAreaRandomlyAs(currentType, xPos, yPos, 5, 0.3f);
                break;
            case Mouse.Button.XButton1:
                automata.SetAreaRandomlyAs(currentType, xPos, yPos, 15, 0.3f);
                break;
            case Mouse.Button.XButton2:
                automata.SetAreaRandomlyAs(currentType, xPos, yPos, 15, 5f);
                break;
        }
    }

    public void HandleMouseButtonRelease(Mouse.Button button)
    {

    }

    public void HandleKeyboardPress(Keyboard.Key key)
    {
        if (key == Keyboard.Key.Space)
        {
            HandleBrush();
            return;
        }
        Console.Write($"{DateTime.Now:HH:mm:ss} ");
        if (key == Keyboard.Key.Delete)
        {
            HandleClear();
            return;
        }
        if (key.ToString().Length == 4 && "0123456789".Contains(key.ToString()[3]))
        {
            HandleGeneration(key);
            return;
        }
        HandleCellChange(key);
        Console.Write($"{currentType.Name}");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(" set as default");
    }

    public void HandleKeyRelease(Keyboard.Key key)
    {
        if (key == Keyboard.Key.Space)
        {
            previousPos = new Vector2i(-1, -1);
        }
    }

    private void HandleBrush()
    {
        var mousePos = Mouse.GetPosition(window);
        if (previousPos.X >= 0)
        {
            float len = (float)Math.Sqrt(Math.Pow(mousePos.X - previousPos.X, 2) + Math.Pow(mousePos.Y - previousPos.Y, 2));

            var xStep = (mousePos.X - previousPos.X) / len;
            var yStep = (mousePos.Y - previousPos.Y) / len;

            float x = mousePos.X;
            float y = mousePos.Y;

            for (int i = 0; i < len + 1; i++)
            {
                automata.Brush(currentType, (int)x, (int)y);
                x += xStep;
                y += yStep;
            }
        }
        else
        {
            automata.Brush(currentType, mousePos.X, mousePos.Y);
        }
        previousPos = mousePos;
    }

    private void HandleClear()
    {
        automata.Reinitialize();
        Console.WriteLine("Automata reinitialized");
    }

    private void HandleCellChange(Keyboard.Key key)
    {
        switch (key)
        {
            case Keyboard.Key.A: currentType = typeof(AirCell); Console.ForegroundColor = ConsoleColor.White; break;
            case Keyboard.Key.W: currentType = typeof(WaterCell); Console.ForegroundColor = ConsoleColor.Blue; break;
            case Keyboard.Key.S: currentType = typeof(SandCell); Console.ForegroundColor = ConsoleColor.Yellow; break;
            case Keyboard.Key.R: currentType = typeof(RockCell); Console.ForegroundColor = ConsoleColor.DarkGray; break;
            case Keyboard.Key.F: currentType = typeof(FireCell); Console.ForegroundColor = ConsoleColor.Red; break;
            case Keyboard.Key.G: currentType = typeof(FlameCell); Console.ForegroundColor = ConsoleColor.Red; break;
            case Keyboard.Key.L: currentType = typeof(LeavesCell); Console.ForegroundColor = ConsoleColor.DarkGreen; break;
            case Keyboard.Key.K: currentType = typeof(WoodCell); Console.ForegroundColor = ConsoleColor.DarkRed; break;
            case Keyboard.Key.Z: currentType = typeof(SmokeCell); Console.ForegroundColor = ConsoleColor.DarkGray; break;
            case Keyboard.Key.X: currentType = typeof(SteamCell); Console.ForegroundColor = ConsoleColor.White; break;
            case Keyboard.Key.Q: currentType = typeof(AcidCell); Console.ForegroundColor = ConsoleColor.Green; break;
            case Keyboard.Key.T: currentType = typeof(SteelCell); Console.ForegroundColor = ConsoleColor.DarkGray; break;
            case Keyboard.Key.O: currentType = typeof(OilCell); Console.ForegroundColor = ConsoleColor.Yellow; break;
            case Keyboard.Key.D: currentType = typeof(GunPowderCell); Console.ForegroundColor = ConsoleColor.DarkGray; break;
            case Keyboard.Key.V: currentType = typeof(AcidVaporCell); Console.ForegroundColor = ConsoleColor.Green; break;
            case Keyboard.Key.C: currentType = typeof(SaltCell); Console.ForegroundColor = ConsoleColor.White; break;
            default: Console.Write("No action assigned: "); return;
        }
    }

    private void HandleGeneration(Keyboard.Key key)
    {
        automataGenerator.Load((int)char.GetNumericValue(key.ToString()[3]));
    }
}
