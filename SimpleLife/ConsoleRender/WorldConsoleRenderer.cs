using SimpleLife.Common;
using SimpleLife.Elements;

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
            string strWorld = ConvertWorldToString();
            Console.WriteLine(strWorld);
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

            for(int i = 0; i < World.foods.Count; i++)
            {
                Food food = World.foods[i];
                stringWorld[food.Coord.X, food.Coord.Y] = ConsoleRendererConfig.FOOD_CELL;
            }

            for (int i = 0; i < World.poisons.Count; i++)
            {
                Poison poison = World.poisons[i];
                stringWorld[poison.Coord.X, poison.Coord.Y] = ConsoleRendererConfig.POISON_CELL;
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
