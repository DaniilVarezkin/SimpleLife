using SimpleLife.Elements;
using SimpleLife.Units;

namespace SimpleLife.ConsoleRender
{
    public class WorldConsoleRenderer
    {
        public World World { get; set; }

        public WorldConsoleRenderer(World world)
        {
            World = world;
        }

        public void Render()
        {
            Console.CursorVisible = false;
            Console.Clear();
            string strWorld = ConvertWorldToString();
            Console.Write(strWorld);
        }

        private string ConvertWorldToString()
        {

            string[,] stringWorld = new string[World.Width, World.Height];

            for (int i = 0; i < stringWorld.GetLength(0); i++)
            {
                for (int j = 0; j < stringWorld.GetLength(1); j++)
                {
                    stringWorld[i, j] = ConsoleRendererConfig.EMPTY_CELL;
                }
            }

            foreach (var cell in World.Cells)
            {
                if (cell is Wall wall)
                    stringWorld[wall.Coord.X, wall.Coord.Y] = ConsoleRendererConfig.WALL_CELL;
                else if (cell is Food food)
                    stringWorld[food.Coord.X, food.Coord.Y] = ConsoleRendererConfig.FOOD_CELL;
                else if (cell is Poison poison)
                    stringWorld[poison.Coord.X, poison.Coord.Y] = ConsoleRendererConfig.POISON_CELL;
                else if (cell is Unit unit)
                    stringWorld[unit.Coord.X, unit.Coord.Y] = ConsoleRendererConfig.UNIT_CELL;

            }

            string[] lines = new string[World.Height];

            for (int j = 0; j < stringWorld.GetLength(1); j++)
            {
                lines[j] = "";
                for (int i = 0; i < stringWorld.GetLength(0); i++)
                {
                    lines[j] += stringWorld[i, j];
                }
            }

            return string.Join("\n", lines);
        }


    }
}
