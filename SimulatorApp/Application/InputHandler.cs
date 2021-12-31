using SFML.Window;
using SimulatorApp.Common.Cells;

namespace SimulatorApp.Application;

public class InputHandler
{
    private readonly CellularAutomata automata;
    private Type currentType;

    public InputHandler(CellularAutomata automata)
    {
        this.automata = automata;
        currentType = typeof(AirCell);
    }

    public void HandleMouseClick(Mouse.Button button, int xPos, int yPos)
    {
        switch (button)
        {
            case Mouse.Button.Left:
                automata.SetAreaAs(currentType, xPos, yPos, 2, 1f);
                break;
            case Mouse.Button.Right:
                automata.SetAreaAs(currentType, xPos, yPos, 4, 5f);
                break;
            case Mouse.Button.Middle:
                automata.SetAreaAs(currentType, xPos, yPos, 5, 0.3f);
                break;
            case Mouse.Button.XButton1:
                automata.SetAreaAs(currentType, xPos, yPos, 15, 0.3f);
                break;
            case Mouse.Button.XButton2:
                automata.SetAreaAs(currentType, xPos, yPos, 15, 5f);
                break;
        }
    }

    public void HandleKeyboardPress(Keyboard.Key key)
    {
        if (key == Keyboard.Key.Delete)
        {
            automata.Reinitialize();
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fF} Automata reinitialized");
            return;
        }
        Console.Write($"{DateTime.Now:HH:mm:ss.fF} ");
        switch (key)
        {
            case Keyboard.Key.W: currentType = typeof(WaterCell); Console.ForegroundColor = ConsoleColor.Blue; break;
            case Keyboard.Key.S: currentType = typeof(SandCell); Console.ForegroundColor = ConsoleColor.Yellow; break;
            case Keyboard.Key.R: currentType = typeof(RockCell); Console.ForegroundColor = ConsoleColor.DarkGray; break;
            default: Console.WriteLine("No action\n"); return;
        }
        Console.Write($"{currentType.Name}");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(" set as default\n");
    }
}
