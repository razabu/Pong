using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong2
{
    public class GameManager
    {
        #region Private Fields

        private List<IGameElement> _gameElements;

        #endregion

        #region Constructor

        public GameManager()
        {
            this._gameElements = new List<IGameElement>();
            this.Initialize();
        }

        #endregion

        #region Private Methods

        private void Initialize()
        {
            this._gameElements.Add(new Background());
            
            Racket humanPlayer = new Racket(true);
            Racket computerPlayer = new Racket(false);
            
            this._gameElements.Add(humanPlayer);
            this._gameElements.Add(computerPlayer);

            Ball ball = new Ball(humanPlayer, computerPlayer);
            computerPlayer.BallReference = ball;
            this._gameElements.Add(ball);
            this._gameElements.Add(new Scores(ball));
        }

        #endregion

        #region Public Methods

        public void Update()
        {
            if ((this._gameElements.First(e => e is Scores) as Scores).Winner == 0)
            {
                foreach (IGameElement element in this._gameElements)
                    element.Update();
            }
        }

        public void Draw(Graphics graphics)
        {
            foreach (IGameElement element in this._gameElements)
                element.Draw(graphics);
        }

        //public void HandleInput(KeyEventArgs keyEvent)
        //{
        //    (this._gameElements.First(e => e is Racket && (e as Racket).IsHumanPlayer) as Racket).HandleInput(keyEvent);
        //}

        public void HandleInput(Keys keyData)
        {
            (this._gameElements.First(e => e is Racket && (e as Racket).IsHumanPlayer) as Racket).HandleInput(keyData);
        }

        #endregion
    }
}
