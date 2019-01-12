using Microsoft.Xna.Framework;

namespace ConsoleAppTest.Services
{

    public interface IGameManager
    {
        void Init();

        void Update(GameTime time);
    }

}
