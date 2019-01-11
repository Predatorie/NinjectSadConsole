using ConsoleAppTest.Services;
using Ninject.Modules;

namespace ConsoleAppTest.Modules
{

    public class GameModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IKeyboardService>().To<KeyboardService>().InSingletonScope();
        }
    }

}
