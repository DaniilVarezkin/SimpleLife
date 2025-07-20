using SimpleLife;
using SimpleLife.ConsoleRender;
using SimpleLife.Units;

World world = new World();

world.AddCells();

while (true)
{
    world.Iteration();
    WorldConsoleRenderer renderer = new WorldConsoleRenderer(world);

    renderer.Render();

    Thread.Sleep(100);
}



