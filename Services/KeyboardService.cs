namespace ConsoleAppTest.Services
{

    using Microsoft.Xna.Framework.Input;
    using SadConsole;

    public class KeyboardService : IKeyboardService
    {
        public void IsKeyReleased(Keys key)
        {
            if(Global.KeyboardState.IsKeyReleased(Keys.F5))
            {
                Settings.ToggleFullScreen();
            }
        }
    }

}
