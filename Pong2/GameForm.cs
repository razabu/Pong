using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong2
{
    public partial class GameForm : Form
    {
        #region Static Fields

        public static Size ScreenSize;

        #endregion

        #region Private Fields

        private GameManager _gameManager;
        
        #endregion

        #region Public Methods

        public GameForm()
        {
            InitializeComponent();
            ScreenSize = this.ClientSize;
            this._gameManager = new GameManager();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            this.GameTimer.Interval = 10;
            this.GameTimer.Start();
        }

        #endregion

        #region Events

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            this._gameManager.Update();
            this._gameManager.Draw(e.Graphics);
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                this._gameManager.HandleInput(e.KeyCode);
        }

        #endregion
    }
}
