using Microsoft.Xna.Framework.Input;

namespace ConsoleAppTest.Services
{

    using SadConsole;

    public class KeyboardService : IKeyboardService
    {
        public void IsKeyDown(Keys key)
        {
            // As an example, we'll use the F5 key to make the game full screen
            if(Global.KeyboardState.IsKeyDown(Keys.F5))
            {
                Settings.ToggleFullScreen();
            }
        }
    }

}
