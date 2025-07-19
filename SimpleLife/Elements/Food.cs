using SimpleLife.Common;

namespace SimpleLife.Elements
{
    public class Food : Cell
    {
        public Food(Coord coord) : base(coord) { }

        public int cost = Config.FOOD_COST;
    }
}
