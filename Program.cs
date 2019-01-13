namespace ConsoleAppTest
{

    using ConsoleAppTest.Modules;
    using ConsoleAppTest.Services;
    using Microsoft.Xna.Framework;
    using Ninject;
    using SadConsole;
    using SadConsole.Themes;
    using Game = SadConsole.Game;

    public class Program
    {
        public static int GameHeight = 36;

        public static int GameWidth = 100;

        private static IConsoleService consoleService;

        private static IGameManager gameManager;

        private static void Init()
        {
            Colors.ControlHostBack = Color.Black;

            SadConsole.Game.Instance.Window.Title = "JARL";

            var container = new ConsoleContainer();
            container.Children.Add(consoleService.CreateMap());
            container.Children.Add(consoleService.CreateMessageLog());
            container.Children.Add(consoleService.CreateStats());

            Global.CurrentScreen.Children.Add(container);
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
                consoleService = kernel.Get<IConsoleService>();
            }
        }

        private static void Update(GameTime time)
        {
            gameManager.Update(time);
        }
    }

}
