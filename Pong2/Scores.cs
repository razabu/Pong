using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong2
{
    public class Scores : IGameElement
    {
        #region Properties

        public int Winner 
        {
            get { return this._winner; }
        }

        #endregion

        #region Private Fields

        private int _player1Score;
        private int _player2Score;
        private Ball _ballReference;
        private int _winner = 0;

        #endregion

        #region Constructor

        public Scores(Ball ball)
        {
            this._ballReference = ball;
            this._player1Score = 10;
            this._player2Score = 10;
        }

        #endregion

        #region Public Methods

        public void Update() 
        {
            if (this._ballReference.Position.X < 0)
                this._player1Score--;
            if (this._ballReference.Position.X > GameForm.ScreenSize.Width)
                this._player2Score--;

            if (this._player1Score == 0)
                this._winner = 2;
            if (this._player2Score == 0)
                this._winner = 1;
        }

        public void Draw(Graphics graphics)
        {
            int screenWidth = GameForm.ScreenSize.Width;
            int screenHeight = GameForm.ScreenSize.Height;

            Font font = new Font("Arial", 50);
            graphics.DrawString(_player1Score.ToString(), font, Brushes.White, screenWidth / 2 - graphics.MeasureString(_player1Score.ToString(), font).Width, 10);
            graphics.DrawString(_player2Score.ToString(), font, Brushes.White, screenWidth / 2 , 10);

            if(this._winner == 1)
                graphics.DrawString("Você venceu!!! :D", font, Brushes.Yellow, 50, 100);
            if(this._winner == 2)
                graphics.DrawString("Não consegue né Moisés!", font, Brushes.Red, 50, 100);
        }

        #endregion
    }
}
