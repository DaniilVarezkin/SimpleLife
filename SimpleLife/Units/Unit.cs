using SimpleLife.Common;

namespace SimpleLife.Units
{
    public class Unit : Cell
    {
        public int Direction { get; set; }
        public Genome Genome { get; set; }
        public int Health { get; set; } = 100;

        public Unit(Genome genome, Coord coord) : base(coord) 
        {
            Genome = genome;
        }

        public void Control()
        {
            for(int i = 0; i < 10; i++)
            {
                if(Genome.ReadNextCommand() != true) break;
            }
        }

        public void AddHealth(int value)
        {
            Health = Math.Min(Config.MAX_HEALTH, Health + value);
        }

        public void SubtractHealth(int value)
        {
            Health = Math.Max(0, Health - value);
        }

        public int CheckThere(int direction)
        {
            Console.WriteLine($"Проверяю по направлению {direction}");
            return 0;
        }

        public void Rotate(int direction)
        {
            Console.WriteLine($"Поворачиваюсь по направлению {direction}");
        }

        public int Move(int direction)
        {
            Console.WriteLine($"Иду по направлению {direction}");
            return 0;
        }

        public int Grab(int direction)
        {
            Console.WriteLine($"Хватаю по направлению {direction}");
            return 0;
        }

        
    }
}
