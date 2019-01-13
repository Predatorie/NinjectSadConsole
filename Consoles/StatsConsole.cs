using System;
using SadConsole.Input;

namespace ConsoleAppTest.Consoles
{

    class StatsConsole : BorderedConsole
    {
        public StatsConsole(int width, int height, string header) : base(width, height, header)
        {
        }

        public override void Draw(TimeSpan timeElapsed) => base.Draw(timeElapsed);

        public override bool ProcessKeyboard(Keyboard info) => base.ProcessKeyboard(info);

        public override bool ProcessMouse(MouseConsoleState state) => base.ProcessMouse(state);

        public override void Update(TimeSpan delta) => base.Update(delta);
    }

}
