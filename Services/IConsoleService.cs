namespace ConsoleAppTest.Services
{

    using SadConsole;

    public interface IConsoleService
    {
        GameSize GameSize { get; }

        Console CreateMap();

        Console CreateMessageLog();

        Console CreateStats();
    }

    public struct GameSize
    {
        public int Height { get; set; }

        public int Width { get; set; }
    }

}
