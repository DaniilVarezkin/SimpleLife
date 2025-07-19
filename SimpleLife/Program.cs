using SimpleLife;
using SimpleLife.ConsoleRender;
using SimpleLife.Units;

World world = new World();

world.StartLife();

WorldConsoleRenderer renderer = new WorldConsoleRenderer(world);

renderer.Render();

