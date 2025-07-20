namespace SimpleLife.ConsoleRender
{
    public static class ConsoleRendererConfig
    {
        public static string EMPTY_CELL = "  ";
        public static string FOOD_CELL = "\u001b[42m[]\u001b[0m";
        public static string POISON_CELL = "\u001b[41m[]\u001b[0m";
        public static string UNIT_CELL = "\u001b[46m[]\u001b[0m";
        public static string WALL_CELL = "\u001b[47m[]\u001b[0m";
    }
}
