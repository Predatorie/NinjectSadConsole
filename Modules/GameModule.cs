namespace ConsoleAppTest.Modules
{

    using ConsoleAppTest.Services;
    using Ninject.Modules;

    public class GameModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IConsoleService>()
                .To<ConsoleService>()
                .InSingletonScope()
                .WithConstructorArgument("gameSize",
                                         new GameSize()
                {
                    Width = Program.GameWidth,
                    Height = Program.GameHeight
                });

            this.Bind<IKeyboardService>()
                .To<KeyboardService>()
                .InSingletonScope();

            this.Bind<IGameManager>()
                .To<GameManager>()
                .InSingletonScope();
        }
    }

}
