using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SimulatorApp.Common;
using SimulatorApp.Common.Cells.LiquidCells;
using SimulatorApp.Common.Cells.SolidCells.DynamicSolidCells;

namespace SimulatorApp.Application;

public class Simulator
{
    private RenderWindow _window;
    private CellularAutomata _automata;

    public Simulator()
    {
        var x = (uint)(Settings.X - 1);
        var y = (uint)(Settings.Y - 1);

        _automata = new CellularAutomata();
        _window = new RenderWindow(new VideoMode((uint)(x * Settings.Scale), (uint)(y * Settings.Scale)), "Simulator", Styles.Default);
        _window.SetFramerateLimit((uint)Settings.FPS);
        _window.SetView(new View(new FloatRect(0, 0, x, y)));
        _window.GetView().Size = new Vector2f(Settings.X * Settings.Scale, Settings.Y * Settings.Scale);

        _window.Closed += OnClosed;
        _window.KeyPressed += OnKeyPress;
        _window.MouseButtonPressed += OnMouseButtonPressed;
    }

    public void MainLoop()
    {
        while (_window.IsOpen)
        {
            ClearWindow();
            _automata.Update();
            DrawAndDisplay();
        }
    }

    public void DrawAndDisplay()
    {
        _window.Draw(_automata);
        _window.Display();
    }

    public void ClearWindow()
    {
       _window.DispatchEvents();
       _window.Clear(Colors.Background);
    }

    private void OnClosed(object sender, EventArgs e)
    {
        _window.Close();
    }

    private void OnKeyPress(object sender, KeyEventArgs e)
    {
        switch (e.Code)
        {
            case Keyboard.Key.Escape:
                _window.Close();
                break;
        }
    }

    private void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
    {
        switch (e.Button)
        {
            case Mouse.Button.Left:
                _automata.SetAreaAs(typeof(SandCell), e.X, e.Y, 5, 5f);
                break;
            case Mouse.Button.Right:
                _automata.SetAreaAs(typeof(WaterCell), e.X, e.Y, 5, 5f);
                break;
        }
    }
}