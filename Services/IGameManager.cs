namespace ConsoleAppTest.Services
{

    using Microsoft.Xna.Framework;

    public interface IGameManager
    {
        void Init();

        void Update(GameTime time);
    }

}
