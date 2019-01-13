namespace ConsoleAppTest.Services
{

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class GameManager : IGameManager
    {
        private readonly IKeyboardService keyboardService;

        public GameManager(IKeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        public void Init()
        {
        }

        public void Update(GameTime time)
        {
            this.keyboardService.IsKeyReleased(Keys.F5);
        }
    }

}
