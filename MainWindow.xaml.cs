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
using tic_tac_toe.src;

namespace tic_tac_toe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ImageKeeper ik = ImageKeeper.Init();
        

        public int move = 1;
        //1 or 2


        public MainWindow()
        {
            //инициализируем компонент и добавляем в базу 2 картинки
            InitializeComponent();
            ik.AddImage("source/121212.png");
            ik.AddImage("source/212121.png");
            //устанавливааем картинку кода
            Chenge_img();
        }

        /// <summary>
        /// Функция обработки нажатия клавишь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //получаем обьект кнопку-отправитель
            Button thisButton = (Button)(e.OriginalSource);
            //получаем имя дочернего Grida (Можно лучше через Content)
            string nameGrid = thisButton.Name + "grid";
            //Получаем обьект Grid 
            Grid grid = (Grid)(thisButton.FindName(nameGrid));
            //Проверяем пустой ли Grid
            if(grid.Children.Count != 0)
            {
                return;
            }
            //если он пустой
            if (move == 1)
            {
                //добавляем к grid изображение из базы
                grid.Children.Add((Image)ik.Clone(0));
                //добвляем крестик (1) в MapManager 
                MapManager.Map[Grid.GetRow(thisButton), Grid.GetColumn(thisButton)] = move;
                //вызов фунции проверки на победу
                int[] arr = MapManager.ForWin(move);
                if (arr != null)
                {

                    Ka.Text = arr[0].ToString() + arr[1].ToString() + arr[2].ToString() + arr[3].ToString();
                    GridMap.Children.Add(MapManager.DrawLine(arr));
                }


                //изменяем ход
                move = 2;
                //изменяем картинку хода
                Chenge_img();

            }
            else
            {
                //добавляем к grid изображение из базы
                grid.Children.Add((Image)ik.Clone(1));
                //добавим нолик (0) в MapManager 
                MapManager.Map[Grid.GetRow(thisButton), Grid.GetColumn(thisButton)] = move;
                //дебаг - часть - вырезать потом
                Ka.Text = "";
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Ka.Text += Convert.ToString(MapManager.Map[i, j]);
                    }
                    Ka.Text += "\n";
                }

                //вызов фунции проверки на победу
                int[] arr = MapManager.ForWin(move);
                if (arr != null)
                {
                    Ka.Text = arr[0].ToString() + arr[1].ToString() + arr[2].ToString() + arr[3].ToString();
                    GridMap.Children.Add(MapManager.DrawLine(arr));
                }

                //изменяем ход
                move = 1;
                //изменяем картинку хода
                Chenge_img();
            }
        }

        ///Фунция стерающая все изображения на всех кнопках 
        private void Update_Map(object sender, RoutedEventArgs e)
        {
            GridMap.Children.Clear();
            MapManager.MapClear();
            foreach(object Child in GridMain.Children)
            {
                if(Child is Button)
                {
                    Button thisButton = (Button)Child;
                    Grid grid = (Grid)(thisButton.FindName(thisButton.Name + "grid"));
                    grid.Children.Clear();
                    move = 1;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    MapManager.Map[i, j] = 0;
                }
            }
            Chenge_img();
        }
        /// <summary>
        /// просто функция меняющая местами картинки
        /// </summary>
        void Chenge_img()
        {

            if (move == 1)
            {
                if (StatGrid.Children.Count != 0)
                {
                    StatGrid.Children.Clear();
                    Ka.Text = Convert.ToString(StatGrid.Children.Count);
                }
                StatGrid.Children.Add((Image)ik.Clone(0));
            }
            else
            {
                if (StatGrid.Children.Count != 0)
                {
                    StatGrid.Children.Clear();
                }
                
                StatGrid.Children.Add((Image)ik.Clone(1));
            }
        }


        
    }
}
