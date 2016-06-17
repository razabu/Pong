using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong2
{
    public class Background : IGameElement
    {
        #region Public Methods

        public void Update() {}

        public void Draw(Graphics graphics)
        {
            int screenWidth = GameForm.ScreenSize.Width;
            int screenHeight = GameForm.ScreenSize.Height;

            Pen pen = new Pen(Color.White, 10);

            graphics.DrawRectangle(pen, new Rectangle(Point.Empty, GameForm.ScreenSize));

            pen.DashStyle = DashStyle.Dot;

            graphics.DrawLine(pen, new Point(screenWidth / 2, 5), new Point(screenWidth / 2, screenHeight));
        }

        #endregion
    }
}
