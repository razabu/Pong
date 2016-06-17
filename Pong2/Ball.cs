using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong2
{
    public class Ball : IGameElement
    {
        #region Properties

        private Point _position;
        public Point Position
        {
            get { return this._position; }
        }

        #endregion

        #region Private Fields

        private int _xSpeed;
        private int _ySpeed;
        private Racket _player1;
        private Racket _player2;

        #endregion

        #region Constants

        private const int SIZE = 10;

        #endregion

        #region Constructor

        public Ball(Racket player1, Racket player2)
        {
            this._player1 = player1;
            this._player2 = player2;
            this.Initialize();
        }

        #endregion

        #region Private Methods

        private void Initialize()
        {
            Random rand = new Random();

            this._position.X = GameForm.ScreenSize.Width / 2;
            this._position.Y = rand.Next(10, GameForm.ScreenSize.Height - 10);

            this._xSpeed = rand.Next(-10, 10);
            this._ySpeed = rand.Next(-5, 5);

            while (this._xSpeed == 0)
                this._xSpeed = rand.Next(-10, 10);
            while (this._ySpeed == 0)
                this._ySpeed = rand.Next(-5, 5);
        }

        private void CheckWallCollision()
        {
            if (this._position.Y <= 0 || this._position.Y >= GameForm.ScreenSize.Height)
                this._ySpeed *= -1;
        }

        private void CheckIfPoint()
        {
            if (this._position.X < 0 || this._position.X > GameForm.ScreenSize.Width)
                this.Initialize();
        }

        private void CheckRacketCollision()
        {
            bool leftPlayerCollision = this._position.Y >= this._player1.Position.Y && this._position.Y <= this._player1.Position.Y + this._player1.RacketSize.Height &&
                this._position.X <= this._player1.Position.X + this._player1.RacketSize.Width;

            bool rightPlayerCollision = this._position.Y >= this._player2.Position.Y && this._position.Y <= this._player2.Position.Y + this._player2.RacketSize.Height &&
                this._position.X >= this._player2.Position.X;

            if (leftPlayerCollision || rightPlayerCollision)
            {
                this._xSpeed *= -1;
                if (this._xSpeed < 0) this._xSpeed--;
                else this._xSpeed++;
            }
        }

        private void Move()
        {
            this._position.X += this._xSpeed;
            this._position.Y += this._ySpeed;
        }

        #endregion

        #region Public Methods

        public void Update()
        {
            this.CheckIfPoint();
            this.CheckWallCollision();
            this.CheckRacketCollision();
            this.Move();
        }

        public void Draw(Graphics graphics)
        {
            int screenWidth = GameForm.ScreenSize.Width;
            int screenHeight = GameForm.ScreenSize.Height;

            graphics.FillRectangle(Brushes.Yellow, new Rectangle(this._position.X, this._position.Y, SIZE, SIZE));
        }

        #endregion
    }
}
