using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Robot
{
    public enum DireccioRobot
    {
        Dreta,
        Esquerre,
        Avall,
        Amunt,
    }
    public enum EnMoviment
    {
        Endavant,
        Quiet
    }
    public class robotGame
    {
        public const int x_SIZE = 5;
        public const int y_SIZE = 5;
        private string movDireccio;
        static Random rnd = new Random();
        Point robot = new Point(rnd.Next(0, 5), rnd.Next(0,5));
        DireccioRobot direccio = DireccioRobot.Avall;
        EnMoviment enMoviment = EnMoviment.Quiet;


        public Point robotPos { get => robot; set => robot = value; }
        public DireccioRobot Direccio { get => direccio; set => direccio = value; }
        public string MovDireccio { get => movDireccio; set => movDireccio = value; }
        public EnMoviment EnMoviment { get => enMoviment; set => enMoviment = value; }

        internal void moure()
        {
            if(enMoviment == EnMoviment.Endavant)
            {
                if (direccio == DireccioRobot.Avall && robot.Y!=5)
                    robot.Y++;
                else if (direccio == DireccioRobot.Amunt && robot.Y !=0)
                    robot.Y--;
                else if (direccio == DireccioRobot.Esquerre && robot.X != 0)
                    robot.X--;
                else if (direccio == DireccioRobot.Dreta && robot.X != 5)
                    robot.X++;
            }
        }
    }
}
