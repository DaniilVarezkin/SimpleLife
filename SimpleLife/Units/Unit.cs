using SimpleLife.Common;

namespace SimpleLife.Units
{
    public class Unit : Cell
    {
        public int Direction { get; set; }
        public Genome Genome { get; set; }
        public int Health { get; set; } = 35;
        public bool IsAlive => Health > 0;

        public World World { get; set; }

        public Unit(World world, Genome genome, Coord coord) : base(coord) 
        {
            World = world;
            Genome = genome;
            genome.SetUnit(this);
        }

        public void Control()
        {
            if (!IsAlive) return;
            for (int i = 0; i < 10; i++)
            {
                if (!Genome.ReadNextCommand()) return;
            }
            SubtractHealth(1);
        }

        public void AddHealth(int value)
        {
            Health = Math.Min(Config.MAX_HEALTH, Health + value);
        }

        public void SubtractHealth(int value)
        {
            Health = Math.Max(0, Health - value);
            if(!IsAlive) World.Units.Remove(this);
        }

        public int CheckThere(int direction)
        {
            int dir = (Direction + direction) % 8;
            Coord coord = getCoordByDiraction(dir);

            return World.IsSomeHere(coord);
        }

        public void Rotate(int direction)
        {
            if (!IsAlive) return;
                Direction = (Direction + direction) % 8;
        }

        public int Move(int direction)
        {

            int dir = (Direction + direction) % 8;
            Coord coord = getCoordByDiraction(dir);

            int result = World.IsSomeHere(coord);

            if (result == 0)
            {
                Coord = coord;
                return result;
            }
            else if(result == 1)
            {
                Coord = coord;
                SubtractHealth(80);
                return result;
            }
            else if (result == 2)
            {
                Coord = coord;
                AddHealth(10);
                return result;
            }
            else if (result == 3 || result == 4)
            {
                return result;
            }
            return result;
        }

        public int Grab(int direction)
        {
            int dir = (Direction + direction) % 8;
            Coord coord = getCoordByDiraction(dir);

            int result = World.IsSomeHere(coord);

            if (result == 0)
            {
                return result;
            }
            else if (result == 1)
            {
                SubtractHealth(80);
                return result;
            }
            else if (result == 2)
            {
                AddHealth(10);
                return result;
            }
            else if (result == 3 || result == 4)
            {
                return result;
            }
            return result;
        }

        private Coord getCoordByDiraction(int diraction)
        {
            Coord coord = Coord;
            if (diraction == 0)
            { coord.X--; coord.Y++; }
            else if (diraction == 1)
                coord.Y++;
            else if (diraction == 2) {coord.Y++; coord.X++; }
            else if (diraction == 3) coord.X++;
            else if (diraction == 4) {coord.X++; coord.Y--; }
            else if (diraction == 5) coord.Y--;
            else if (diraction == 6) {coord.X--; coord.Y--; }
            else if (diraction == 7) coord.X--;
            return coord;
        }


    }
}
