using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyProject
{

    using Microsoft.Xna.Framework.Input;
    using SadConsole;

    class Program
    {
        public const int Height = 25;

        public const int Width = 80;

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
            // Setup the engine and creat the main window.
            Game.Create("IBM.font", Width, Height);

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

        private static void Update(GameTime time)
        {
            // Called each logic update.

            // As an example, we'll use the F5 key to make the game full screen
            if(Global.KeyboardState.IsKeyReleased(Keys.F5))
            {
                Settings.ToggleFullScreen();
            }
        }
    }

}
