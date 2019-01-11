namespace ConsoleAppTest
{

    using ConsoleAppTest.Modules;
    using ConsoleAppTest.Services;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Ninject;
    using SadConsole;
    using Console = SadConsole.Console;
    using Game = SadConsole.Game;

    public class Program
    {
        public const int Height = 25;

        public const int Width = 80;

        private static IGameManager gameManager;

        private static void Init()
        {
            // Any custom loading and prep. We will use a sample console for now

            var startingConsole = new Console(Width, Height);
            startingConsole.FillWithRandomGarbage();
            startingConsole.Fill(new Rectangle(3, 3, 27, 5), null, Color.Black, 0, SpriteEffects.None);
            startingConsole.Print(6, 5, "Hello from SadConsole", ColorAnsi.CyanBright);

            // Set our new console as the thing to render and process
            Global.CurrentScreen = startingConsole;
        }

        static void Main(string[] args)
        {
            RegisterTypes();

            // Setup the engine and creat the main window.
            Game.Create("Fonts/IBM.font", Width, Height);

            // Hook the start event so we can add consoles to the system.
            Game.OnInitialize = Init;

            // Hook the update event that happens each frame so we can trap keys and respond.
            Game.OnUpdate = Update;

            // Start the game.
            Game.Instance.Run();

            //
            // Code here will not run until the game window closes.
            //

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
            // Called each logic update.
            //if(Global.KeyboardState.IsKeyDown(Keys.F5))
            //{
            //    Settings.ToggleFullScreen();
            //}

            // As an example, we'll use the F5 key to make the game full screen
            gameManager.Update(time);
        }
    }

}
