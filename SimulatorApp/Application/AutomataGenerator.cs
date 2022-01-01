using SimulatorApp.Common.Cells;

namespace SimulatorApp.Application
{
    public class AutomataGenerator
    {
        private CellularAutomata automata;

        public AutomataGenerator(CellularAutomata automata)
        {
            this.automata = automata;
        }

        public void Load(int nr)
        {
            switch (nr)
            {
                case 1: Schema1(); return;
                default: return;
            }
        }

        private void Schema1()
        {
            for (int y = 0; y < automata.Cells.GetUpperBound(1); y++)
            {
                for (int x = 0; x < automata.Cells.GetUpperBound(0); x++)
                {
                    automata.Cells[x, y] = new AirCell(x, y);
                }
            }
            Console.WriteLine("Schema1 loaded");
        }
    }
}
