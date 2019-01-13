namespace ConsoleAppTest.Services
{

    using ConsoleAppTest.Consoles;
    using Microsoft.Xna.Framework;
    using SadConsole;

    public class ConsoleService : IConsoleService
    {
        public ConsoleService(GameSize gameSize) => this.GameSize = gameSize;

        public GameSize GameSize { get; }

        public Console CreateMap()
        {
            var mapConsole = new MapConsole(this.GameSize.Width - 20, 25, "-Map-")
            {
                Position = new Point(1, 2),
            };

            mapConsole.Fill(Color.White, Color.Black, 250, null);

            return mapConsole;
        }

        public Console CreateMessageLog()
        => new MessageLogConsole(this.GameSize.Width - 2, 5, "-Message Log-")
        {
            Position = new Point(1, 30)
        };

        public Console CreateStats()
        => new StatsConsole(16, 25, "-Statistics-")
        {
            Position = new Point(83, 2)
        };
    }

}
