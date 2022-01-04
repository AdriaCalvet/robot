using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Robot
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// 
    /// Els moviments son aleatoris no s'ha de premer cap tecla ni res
    /// 50% probabilitat d'anar endavant
    /// 25% probabilitat d'anar esquerre
    /// 25% probabilitat d'anar dreta
    /// 
    /// S'han de comptar el numero de moviments
    /// Guanya quan agafa el tresor
    /// 
    /// Implementar una altre funcio (un altre robot i que compateixin)
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        robotGame robot1 = new robotGame();
        robotGame robot2 = new robotGame();
        Image coin = new Image();
        DispatcherTimer timer = new DispatcherTimer();
        Random rnd = new Random();
        Point coinPos;
        int nWidth, nHeight;
        public MainWindow()
        {
            InitializeComponent();
            crearCoin();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void crearCoin()
        {
            nWidth = rnd.Next(0, 5);
            nHeight = rnd.Next(0, 5);

            Point coinPos = new Point(nWidth, nHeight);
            Canvas.SetTop(coin, coinPos.Y * canvas.ActualHeight * 5);
            Canvas.SetLeft(coin, coinPos.X * canvas.ActualWidth / 5 );
            //Title = nWidth + " " + nHeight;
            coin.Width = 20;
            coin.Height = 20;
            coin.Source = new BitmapImage(new Uri(@"/imatges/coin.png", UriKind.Relative));
            canvas.Children.Add(coin);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            moure(robot1);
            moure(robot2);
            //Title = robot.Direccio.ToString();
            int tamanyXCasella = (int)(canvas.ActualWidth / robotGame.x_SIZE);
            int tamanyYCasella = (int)(canvas.ActualHeight / robotGame.y_SIZE);
            Image robotimg = new Image()
            {
                Width = tamanyXCasella,
                Height = tamanyYCasella,
                Source = new BitmapImage(new Uri(@"/imatges/robot.png", UriKind.Relative))
            };
            Image robotimg1 = new Image()
            {
                Width = tamanyXCasella,
                Height = tamanyYCasella,
                Source = new BitmapImage(new Uri(@"/imatges/robot2.png", UriKind.Relative))
            };
            robot1.moure();
            robot2.moure();
            //canvas.Children.RemoveRange(1, canvas.Children.Count - 1);
            if (!(robot1.robotPos.Y * tamanyYCasella > canvas.ActualHeight || robot1.robotPos.Y * tamanyYCasella < 0))
            {
                Canvas.SetTop(robotimg, robot1.robotPos.Y * tamanyYCasella);
                canvas.Children.RemoveRange(1, 1);
                //canvas.Children.Add(robotimg);
                canvas.Children.Insert(1, robotimg);

            }
            if (!(robot1.robotPos.X * tamanyXCasella > canvas.ActualWidth || robot1.robotPos.X * tamanyXCasella < 0))
            {
                Canvas.SetLeft(robotimg, robot1.robotPos.X * tamanyXCasella);
                canvas.Children.RemoveRange(1, 1);
                //canvas.Children.Add(robotimg);
                canvas.Children.Insert(1, robotimg);
            }

            //2
            if (!(robot2.robotPos.Y * tamanyYCasella > canvas.ActualHeight || robot2.robotPos.Y * tamanyYCasella < 0))
            {
                Canvas.SetTop(robotimg1, robot2.robotPos.Y * tamanyYCasella);
                canvas.Children.RemoveRange(2, 1);
                canvas.Children.Add(robotimg1);
            }
            if (!(robot2.robotPos.X * tamanyXCasella > canvas.ActualWidth || robot2.robotPos.X * tamanyXCasella < 0))
            {
                Canvas.SetLeft(robotimg1, robot2.robotPos.X * tamanyXCasella);
                canvas.Children.RemoveRange(2, 1);
                canvas.Children.Add(robotimg1);
            }

        }

        private void moure(robotGame robot)
        {
            int movRandom = rnd.Next(0, 3);
            if(movRandom == 0 || movRandom == 1)
            {
                robot.EnMoviment = EnMoviment.Endavant;
            }
            else
                robot.EnMoviment = EnMoviment.Quiet;

            //2 - Esquerre
            if (movRandom == 2)
            {
                if (robot.Direccio == DireccioRobot.Amunt)
                    robot.Direccio = DireccioRobot.Esquerre;
                else if (robot.Direccio == DireccioRobot.Esquerre)
                    robot.Direccio = DireccioRobot.Avall;
                else if (robot.Direccio == DireccioRobot.Avall)
                    robot.Direccio = DireccioRobot.Dreta;
                else
                    robot.Direccio = DireccioRobot.Amunt;
            }
            //3 - Dreta
            else if(movRandom == 3)
            {
                if (robot.Direccio == DireccioRobot.Amunt)
                    robot.Direccio = DireccioRobot.Dreta;
                else if (robot.Direccio == DireccioRobot.Dreta)
                    robot.Direccio = DireccioRobot.Avall;
                else if (robot.Direccio == DireccioRobot.Avall)
                    robot.Direccio = DireccioRobot.Esquerre;
                else
                    robot.Direccio = DireccioRobot.Amunt;
            }
        }
    }
}
