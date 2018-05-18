using System.Drawing;

namespace Pacman
{
    public class Pacman
    {
        public enum Direction
        {
            Right,
            Left,
            Up,
            Down
        }

        public int X { get; set; }
        public int Y { get; set; }
        private readonly Brush _brush;
        private Direction _direction;
        public static readonly int Radius = 20;
        private bool _isOpen;

        public Pacman()
        {
            X = 7;
            Y = 5;
            _direction = Direction.Right;
            _brush = new SolidBrush(Color.Yellow);
        }

        public void ChangeDirection(Direction direction)
        {
            _direction = direction;
        }

        public void Move(int width, int height)
        {
            switch (_direction)
            {
                case Direction.Right:
                    X += 1;
                    if (X >= width)
                    {
                        X = 0;
                    }

                    break;
                case Direction.Left:
                    X -= 1;
                    if (X < 0)
                    {
                        X = width - 1;
                    }

                    break;
                case Direction.Up:
                    Y -= 1;
                    if (Y < 0)
                    {
                        Y = height - 1;
                    }

                    break;
                case Direction.Down:
                    Y += 1;
                    if (Y >= height)
                    {
                        Y = 0;
                    }

                    break;
            }
            _isOpen = !_isOpen;
        }

        public void Draw(Graphics g)
        {
            if (!_isOpen)
            {
                g.FillEllipse(_brush, X * 2 * Radius, Y * 2 * Radius, Radius * 2, Radius * 2);
            }
            else
            {
                switch (_direction)
                {
                    case Direction.Right:
                        g.FillPie(_brush, X * 2 * Radius, Y * 2 * Radius, Radius * 2, Radius * 2, 45, 270);
                        break;
                    case Direction.Left:
                        g.FillPie(_brush, X * 2 * Radius, Y * 2 * Radius, Radius * 2, Radius * 2, 225, 270);
                        break;
                    case Direction.Up:
                        g.FillPie(_brush, X * 2 * Radius, Y * 2 * Radius, Radius * 2, Radius * 2, 315, 270);
                        break;
                    case Direction.Down:
                        g.FillPie(_brush, X * 2 * Radius, Y * 2 * Radius, Radius * 2, Radius * 2, 135, 270);
                        break;
                }
            }
        }
    }
}
