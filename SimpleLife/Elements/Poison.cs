using SimpleLife.Common;

namespace SimpleLife.Elements
{
    public class Poison : Cell
    {
        public int Power = Config.POISON_POWER;

        public Poison(Coord coord) : base(coord) { }
    }
}
