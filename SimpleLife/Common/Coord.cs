namespace SimpleLife.Common
{
    public struct Coord
    {
        public int X {  get; set; }
        public int Y { get; set; }

        public Coord(int x, int y) { X = x; Y = y; }

        public static bool operator ==(Coord a, Coord b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Coord a, Coord b)
        {
            return a.X != b.X || a.Y != b.Y;
        }

        public override bool Equals(object obj)
        {
            if (obj is Coord coord)
            {
                return this.X == coord.X && this.Y == coord.Y;
            }
            return false;

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
