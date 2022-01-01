using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SimulatorApp.Application;
using SimulatorApp.Common.Utils;

namespace SimulatorApp.Presentation;

public class Simulator
{
    private RenderWindow window;
    private CellularAutomata automata;
    private InputHandler inputHandler;

#pragma warning disable CS8622
    public Simulator()
    {
        var x = (uint)(Settings.X - 1);
        var y = (uint)(Settings.Y - 1);

        automata = new CellularAutomata();
        window = new RenderWindow(new VideoMode((uint)(x * Settings.Scale), (uint)(y * Settings.Scale)), "Simulator", Styles.Default);
        window.SetView(new View(new FloatRect(0, 0, x, y)));
        window.GetView().Size = new Vector2f(Settings.X * Settings.Scale, Settings.Y * Settings.Scale);
        window.Closed += OnClosed;
        window.KeyPressed += OnKeyPress;
        window.KeyReleased += OnKeyRelease;
        window.MouseButtonPressed += OnMouseButtonPress;
        window.MouseButtonReleased += OnMouseButtonRelease;

        inputHandler = new InputHandler(window, automata);
    }

    public void Run()
    {
        Console.WriteLine($"{DateTime.Now:HH:mm:ss} Starting simulator");
        MainLoop();
        Console.WriteLine($"{DateTime.Now:HH:mm:ss} Closing simulator");
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
        Environment.Exit(0);
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

    private void OnKeyRelease(object sender, KeyEventArgs e)
    {
        inputHandler.HandleKeyRelease(e.Code);
    }

    private void OnMouseButtonPress(object sender, MouseButtonEventArgs e)
    {
        inputHandler.HandleMouseClick(e.Button, e.X, e.Y);
    }

    private void OnMouseButtonRelease(object sender, MouseButtonEventArgs e)
    {
        inputHandler.HandleMouseButtonRelease(e.Button);
    }
}