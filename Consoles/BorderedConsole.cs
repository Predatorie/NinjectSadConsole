namespace ConsoleAppTest.Consoles
{

    using Microsoft.Xna.Framework;
    using SadConsole;
    using SadConsole.Surfaces;

    // We can solve the border problem is by creating a Basic surface and attaching it to our console. 
    // By adding a new surface as a child of the console, it is positioned relative to the console and 
    // it is drawn whenever our console is drawn. The border will be +2,+2 in size, compared to the console.

    // Whenever a new BorderedConsole instance is created, it will display a border around the contents. 
    // The position of your console will have to take into account the fact that the border 
    // will be -1,-1 relative to it.

    public class BorderedConsole : Console
    {
        readonly Basic borderSurface;

        public BorderedConsole(int width, int height) : base(width, height)
        {
            // this.Cursor.Position = new Point(0, 0);
            // this.Cursor.Print("This console has a border around it and the text here wraps inside of it.");

            this.borderSurface = new Basic(width + 2, height + 2, base.Font);

            this.borderSurface
                .DrawBox(new Rectangle(0, 0, this.borderSurface.Width, this.borderSurface.Height),
                         new Cell(Color.White, Color.Black),
                         null,
                         ConnectedLineThick);

            this.borderSurface.Position = new Point(-1, -1);

            this.Children.Add(this.borderSurface);
        }
    }

}

