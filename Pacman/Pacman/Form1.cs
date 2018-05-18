using System;
using System.Drawing;
using System.Windows.Forms;
using Pacman.Properties;

namespace Pacman
{
    public sealed partial class Form1 : Form
    {
        private Timer _timer;
        private Pacman _pacman;
        private const int TimerInterval = 300;
        private const int WorldWidth = 15;
        private const int WorldHeight = 10;
        private readonly Image _foodImage;
        private bool[][] _foodWorld;

        public Form1()
        {
            InitializeComponent();
            _foodImage = Resources.Pacman_peach_sh;
            NewGame();
            DoubleBuffered = true;
        }

        public void NewGame()
        {
            _pacman = new Pacman();
            Width = Pacman.Radius * 2 * (WorldWidth + 1);
            Height = Pacman.Radius * 2 * (WorldHeight + 1);
            _foodWorld = new bool[30][];
            for (var i = 0; i < _foodWorld.Length; i++)
            {
                _foodWorld[i] = new bool[WorldWidth];
                for (var j = 0; j < _foodWorld[i].Length; j++)
                {
                    _foodWorld[i][j] = true;
                }
            }
            _timer = new Timer();
            _timer.Tick +=timer_Tick;
            _timer.Interval = TimerInterval;
            _timer.Start();
          
        }

        void timer_Tick(object sender, EventArgs e)
        {
            for (var i = 0; i < _foodWorld.Length; i++)
            {
                for (var j = 0; j < _foodWorld[i].Length; j++)
                {
                    if (_pacman.X == j && _pacman.Y == i)
                    {
                        _foodWorld[i][j] = false;
                    }
                }
            }
            _pacman.Move(WorldWidth, WorldHeight);
            Invalidate();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    _pacman.ChangeDirection(Pacman.Direction.Up);
                    break;
                case Keys.Down:
                    _pacman.ChangeDirection(Pacman.Direction.Down);
                    break;
                case Keys.Right:
                    _pacman.ChangeDirection(Pacman.Direction.Right);
                    break;
                case Keys.Left:
                    _pacman.ChangeDirection(Pacman.Direction.Left);
                    break;
            }

            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            for (var i = 0; i < _foodWorld.Length; i++)
            {
                for (var j = 0; j < _foodWorld[i].Length; j++)
                {
                    if (_foodWorld[i][j])
                    {
                        e.Graphics.DrawImageUnscaled(_foodImage, j * Pacman.Radius * 2 + (Pacman.Radius * 2 - _foodImage.Height) / 2, i * Pacman.Radius * 2 + (Pacman.Radius * 2 - _foodImage.Width) / 2);
                    }
                }
            }
            _pacman.Draw(e.Graphics);
        }
    }   
}
