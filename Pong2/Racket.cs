using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong2
{
    public class Racket : IGameElement
    {
        #region Properties

        public bool IsHumanPlayer { get; set; }

        private Point _position;
        public Point Position
        {
            get { return this._position; }
        }

        public Size RacketSize 
        {
            get { return new Size(HEIGTH, LENGTH); }
        }

        private Ball _ballReference;
        public Ball BallReference 
        {
            get { return this._ballReference; }
            set { this._ballReference = value; }
        }

        #endregion

        #region Constants

        private const int LENGTH = 80;
        private const int HEIGTH = 10;
        private const int OFFSET = 20;
        private const int MAXSPEED = 15;

        #endregion

        #region Constructor

        public Racket(bool isHumanPlayer)
        {
            this.IsHumanPlayer = isHumanPlayer;
            this.Initialize();
        }

        #region Private Methods

        private void Initialize()
        {
            int screenWidth = GameForm.ScreenSize.Width;
            int screenHeight = GameForm.ScreenSize.Height;

            if (this.IsHumanPlayer)
                this._position = new Point(OFFSET, screenHeight / 2 - LENGTH);
            else
                this._position = new Point(screenWidth - OFFSET * 2, screenHeight / 2 - LENGTH);
        }

        #endregion

        #endregion

        #region Private Methods

        private void AILogic()
        {
            if (this._ballReference.Position.X > GameForm.ScreenSize.Width / 2)
            {
                if (this._ballReference.Position.Y < this._position.Y)
                    this._position.Y -= 8;
                if (this._ballReference.Position.Y > this._position.Y + LENGTH)
                    this._position.Y += 8;
            }
        }

        #endregion

        #region Public Methods

        public void Update()
        {
            int screenHeight = GameForm.ScreenSize.Height;

            if (this._position.Y >= screenHeight - 80)
                this._position.Y = screenHeight - 80;
            else if (this._position.Y <= 0)
                this._position.Y = 0;

            if (!this.IsHumanPlayer)
                this.AILogic();
        }

        public void Draw(Graphics graphics)
        {
            graphics.FillRectangle(Brushes.White, new Rectangle(this._position.X,this._position.Y, HEIGTH, LENGTH));
        }

        public void HandleInput(Keys key)
        {
            if (key == Keys.Up)
                this._position.Y -= MAXSPEED;
            else if (key == Keys.Down)
                this._position.Y += MAXSPEED;
        }

        #endregion
    }
}
