using SimpleLife.Common;
using SimpleLife.Elements;
using SimpleLife.Units;

namespace SimpleLife
{
    public class World
    {
        public int Width { get; set; } = Config.WIDTH;
        public int Height { get; set; } = Config.HEIGHT;

        public List<Unit> Units = new List<Unit>();
        public List<Food> Foods = new List<Food>();
        public List<Poison> Poisons = new List<Poison>();
        public List<Wall> Walls = new List<Wall>();

        public List<Cell> Cells {
            get
            {
                List<Cell> cells = new List<Cell>();
                cells.AddRange(Walls);
                cells.AddRange(Units);
                cells.AddRange(Poisons);
                cells.AddRange(Foods);
                return cells;
            }
        }

        Random rand = new Random();

        public void AddCells()
        {
            addWalls();

            addFood();

            addPoison();

            addUnits();
        }

        public void Iteration()
        {
            foreach (Unit unit in Units.ToList())
            {
                if (unit.IsAlive)
                    unit.Control();
            }
        }
        private void addWalls()
        {
            for(int x = 0; x < Config.WIDTH; x++)
            {
                Walls.Add(new Wall(new Coord(x, 0)));
                Walls.Add(new Wall(new Coord(x, Config.HEIGHT - 1)));
            }

            for (int y = 1; y < Config.HEIGHT - 1; y++)
            {
                Walls.Add(new Wall(new Coord(0, y)));
                Walls.Add(new Wall(new Coord(Config.WIDTH - 1, y)));
            }
        }

        private void addFood()
        {
            for (int i = 0; i < Config.FOOD_COUNT; i++)
            {
                Foods.Add(new Food(getFreeRandomCoord()));
            }
        }

        private void addPoison()
        {
            for (int i = 0; i < Config.POISON_COUNT; i++)
            {
                Poisons.Add(new Poison(getFreeRandomCoord()));
            }
        }

        private void addUnits()
        {
            for (int i = 0; i < Config.START_COUNT_UNITS; i++)
            {
                Genome genome = Genome.CreateFromFile("genome.txt");
                Units.Add(new Unit(this, genome, getFreeRandomCoord()));
            }
        }

        private Coord getFreeRandomCoord()
        {
            Coord coord;
            do
            {
                coord = new Coord(rand.Next(Config.WIDTH), rand.Next(Config.HEIGHT));
            }
            while (IsSomeHere(coord) != 0);
            return coord;
        }


        /// <summary>
        /// Возвращает тип клетки по координатам:
        /// </summary>
        /// <param name="coord"></param>
        /// <returns>
        /// 0 - ничего;
        /// 1 - яд;
        /// 2 - еда;
        /// 3 - живая клетка;
        /// 4 - стена.
        /// </returns>
        public int IsSomeHere(Coord coord)
        {

            var intersectingСells = Cells
                .Where(cell => cell.Coord == coord);

            if(!intersectingСells.Any()) return 0;

            Cell cell = intersectingСells.First();

            if (cell is Poison) return 1;
            else if (cell is Food) return 2;
            else if (cell is Unit) return 3;
            else if (cell is Wall) return 4;

            else return 4;
        }
    }
}
