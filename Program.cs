namespace ConsoleAppTest
{

    using ConsoleAppTest.Modules;
    using ConsoleAppTest.Services;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Ninject;
    using SadConsole;
    using SadConsole.Themes;
    using Console = SadConsole.Console;
    using Game = SadConsole.Game;

    public class Program
    {
        public static int GameHeight = 25;

        public static int GameWidth = 80;

        private static IGameManager gameManager;

        private static void Init()
        {
            Colors.ControlHostBack = Color.Black;

            var startingConsole = new Console(GameWidth, GameHeight);
            startingConsole.Fill(new Rectangle(3, 3, 27, 5), null, Color.Black, 0, SpriteEffects.None);
            startingConsole.Print(6, 5, "Hello from SadConsole", ColorAnsi.CyanBright);

            // Set our new console as the thing to render and process
            Global.CurrentScreen = startingConsole;
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
