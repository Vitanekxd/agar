using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AgarioClone
{
    public partial class MainWindow : Window
    {
        private const double PlayerSpeed = 2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Set player initial position at the center
            Canvas.SetLeft(player, canvas.ActualWidth / 2 - player.Width / 2);
            Canvas.SetTop(player, canvas.ActualHeight / 2 - player.Height / 2);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            // Move player towards the mouse cursor
            Point mousePosition = e.GetPosition(canvas);
            double dx = mousePosition.X - Canvas.GetLeft(player) - player.Width / 2;
            double dy = mousePosition.Y - Canvas.GetTop(player) - player.Height / 2;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            if (distance > 0)
            {
                double speedFactor = PlayerSpeed / distance;
                dx *= speedFactor;
                dy *= speedFactor;

                double newX = Canvas.GetLeft(player) + dx;
                double newY = Canvas.GetTop(player) + dy;

                if (newX >= 0 && newX <= canvas.ActualWidth - player.Width)
                    Canvas.SetLeft(player, newX);

                if (newY >= 0 && newY <= canvas.ActualHeight - player.Height)
                    Canvas.SetTop(player, newY);
            }
        }
    }
}