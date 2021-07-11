using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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


namespace tic_tac_toe.src
{
    static class MapManager
    {
        ///класс будет отвечать за создание карты, и логике победы
        private static int[,] map = new int[,]{
            {0,0,0},
            {0,0,0},
            {0,0,0}
        };

        public static int[,] Map
        {
            get
            {
                return map;
            }
            set
            {
                map = value;
                
            }
        }

        public static void MapClear()
        {
            for(int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = 0;
                }
            }
        }
        ///Функция отрисовывающая линии по входным координатам точек
        public static Line DrawLine(params int[] arg)
        {
            Line ln = new Line();
            ln.Stroke = Brushes.Red;
            ln.StrokeThickness = 3;
            ln.X1 = arg[0] * 100 + 50;
            ln.Y1 = arg[1] * 100 + 50;
            ln.X2 = arg[2] * 100 + 50;
            ln.Y2 = arg[3] * 100 + 50;
            return ln;
        }
        /// <summary>
        /// Возвращает массив элементов в случае победы [X1, X2, X3, X4] и null если ничья или победы нет
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        public static int[] ForWin(int nom)
        {
            
            

            //проверка горизонтали
            for(int i = 0; i < map.GetLength(0); i++)
            {
                Boolean result =  Some_f(0, i , 2, i, nom);
                if (result)
                {
                    return new int[] { 0, i, 2, i };
                }
                
            }
            //проверка горизонтали
            for (int i = 0; i < map.GetLength(1); i++)
            {
                Boolean result = Some_f(i, 0, i, 2, nom);
                if (result)
                {
                    return new int[] { i, 0, i, 2 };
                }
            }

            Boolean res = Some_f(0, 0, 2, 2, nom);
            if (res)
            {
                return new int[] { 0, 0, 2, 2 };
            }
            res = Some_f(0, 2, 2, 0, nom);
            if (res)
            {
                return new int[] { 0, 2, 2, 0 };
            }

            return null;

        }

        //фукция получает координаты начала и конца отрезка и возвращает информацию о том есть заполненна ли эта строка
        private static Boolean Some_f(int x1, int y1, int x2, int y2, int nom)
        {
            if (Map[y1, x1] == nom & Map[(y1 +y2) /2 , (x1+ x2)/2] == nom & Map[y2, x2] == nom)
            {
                return true;
            }
            return false;
        }

    }
}
