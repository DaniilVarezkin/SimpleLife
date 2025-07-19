using SimpleLife.Common;
using SimpleLife.Elements;
using SimpleLife.Units;

namespace SimpleLife
{
    public class World
    {
        public int Width { get; set; } = Config.WIDTH;
        public int Height { get; set; } = Config.HEIGHT;

        public List<Unit> units = new List<Unit>();
        public List<Food> foods = new List<Food>();
        public List<Poison> poisons = new List<Poison>();

        Random rand = new Random();

        public void StartLife()
        {
            for(int i = 0; i < Config.START_COUNT_UNITS; i++)
            {
                Genome genome = Genome.CreateFromFile("genome.txt");
                units.Add(new Unit(genome, getRandomCoord()));
            }

            for(int i = 0; i < Config.FOOD_COUNT; i++)
            {
                foods.Add(new Food(getRandomCoord()));
            }

            for (int i = 0; i < Config.POISON_COUNT; i++)
            {
                poisons.Add(new Poison(getRandomCoord()));
            }

        }

        private Coord getRandomCoord()
        {
            return new Coord(
                        rand.Next(Config.WIDTH),
                        rand.Next(Config.HEIGHT)
                        );
        }
    }
}
