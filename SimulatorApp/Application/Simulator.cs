using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SimulatorApp.Common;

namespace SimulatorApp.Application;

public class Simulator
{
    private RenderWindow window;
    private CellularAutomata automata;
    private InputHandler inputHandler;

    public Simulator()
    {
        var x = (uint)(Settings.X - 1);
        var y = (uint)(Settings.Y - 1);

        automata = new CellularAutomata();
        window = new RenderWindow(new VideoMode((uint)(x * Settings.Scale), (uint)(y * Settings.Scale)), "Simulator", Styles.Default);
        window.SetFramerateLimit((uint)Settings.FPS);
        window.SetView(new View(new FloatRect(0, 0, x, y)));
        window.GetView().Size = new Vector2f(Settings.X * Settings.Scale, Settings.Y * Settings.Scale);

        window.Closed += OnClosed;
        window.KeyPressed += OnKeyPress;
        window.MouseButtonPressed += OnMouseButtonPressed;

        inputHandler = new InputHandler(automata);
    }

    public void MainLoop()
    {
        while (window.IsOpen)
        {
            ClearWindow();
            automata.Update();
            DrawAndDisplay();
        }
    }

    public void DrawAndDisplay()
    {
        window.Draw(automata);
        window.Display();
    }

    public void ClearWindow()
    {
        window.DispatchEvents();
        window.Clear(Colors.Background);
    }

    private void OnClosed(object sender, EventArgs e)
    {
        window.Close();
    }

    private void OnKeyPress(object sender, KeyEventArgs e)
    {
        if (e.Code == Keyboard.Key.Escape)
        {
            window.Close();
            return;
        }
        inputHandler.HandleKeyboardPress(e.Code);
    }

    private void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
    {
        inputHandler.HandleMouseClick(e.Button, e.X, e.Y);
    }
}