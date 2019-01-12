using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ConsoleAppTest.Services
{

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
            this.keyboardService.IsKeyPressed(Keys.F5);
        }
    }

}
