namespace ConsoleAppTest
{

    using ConsoleAppTest.Consoles;
    using ConsoleAppTest.Modules;
    using ConsoleAppTest.Services;
    using Microsoft.Xna.Framework;
    using Ninject;
    using SadConsole;
    using SadConsole.Entities;
    using SadConsole.Surfaces;
    using SadConsole.Themes;
    using Game = SadConsole.Game;

    public class Program
    {
        public static int GameHeight = 34;

        public static int GameWidth = 100;

        private static IGameManager gameManager;

        private static void Init()
        {
            Colors.ControlHostBack = Color.Black;

            // Setup window
            SadConsole.Game.Instance.Window.Title = "JARL - Powered by SadConsole";

            var mapConsole = new BorderedConsole(GameWidth - 20, 25)
            {
                Position = new Point(1, 1)
            };

            mapConsole.Fill(Color.White, Color.Black, 250, null);

            var animation = new Animated("player", 1, 1);
            var frame = animation.CreateFrame();
            frame[0].Glyph = 1;
            frame[0].Foreground = Color.GreenYellow;
            frame[0].Background = Color.Transparent;

            var entity = new Entity(animation)
            {
                Position = new Point(1, 1)
            };

            var manager = new EntityManager();
            manager.Entities.Add(entity);

            Global.CurrentScreen.Children.Add(mapConsole);
            mapConsole.Children.Add(manager);

            var messageLogConsole = new BorderedConsole(GameWidth - 2, 5)
            {
                Position = new Point(1, 28)
            };

            Global.CurrentScreen.Children.Add(messageLogConsole);

            var mapStatsConsole = new BorderedConsole(16, 25)
            {
                Position = new Point(83, 1)
            };

            Global.CurrentScreen.Children.Add(mapStatsConsole);

            Global.FocusedConsoles.Set(mapConsole);
        }

        static void Main(string[] args)
        {
            RegisterTypes();

            Settings.ResizeMode = Settings.WindowResizeOptions.Scale;

            // Setup the engine and create the main window.
            Game.Create("Fonts/IBM.font", GameWidth, GameHeight);

            // Hook the start event so we can add consoles to the system.
            Game.OnInitialize = Init;

            // Hook the update event that happens each frame so we can trap keys and respond.
            Game.OnUpdate = Update;

            // Start the game.
            Game.Instance.Run();

            // Clean up
            Game.Instance.Dispose();
        }

        private static void RegisterTypes()
        {
            using(IKernel kernel = new StandardKernel(new GameModule()))
            {
                gameManager = kernel.Get<IGameManager>();
            }
        }

        private static void Update(GameTime time)
        {
            gameManager.Update(time);
        }
    }

}
