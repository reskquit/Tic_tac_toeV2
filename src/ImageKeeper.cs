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

namespace tic_tac_toe.src
{
    public class ImageKeeper : ICloneable
    {
        /// <summary>
        /// Создание обьекта изображения
        /// 
        /// Создание BitMap загрузчика
        /// 
        /// Инициализация загрузчика
        /// 
        /// Инициализация класса-ссылки на файл
        /// 
        /// Добавление классу Image эту ссылку
        /// 
        /// конец загрузчика
        /// 
        /// Image img2 = new Image();
        /// BitmapImage src2 = new BitmapImage();
        /// src2.BeginInit();
        /// src2.UriSource = new Uri("source/212121.png", UriKind.RelativeOrAbsolute);
        /// img2.Source = src2;
        /// src2.EndInit();     
        /// </summary>
        private static List<Image> ImageLibrary = new List<Image>();
        private static List<string> Paths = new List<string>();
        private static List<BitmapImage> BitmapImages = new List<BitmapImage>();

        private static ImageKeeper Ik;

        public void AddImage(string path, Image img = null)
        {
            //Если обьект изображения не был отдан то создаем обьект изображения
            if(img == null)
            {
                img = new Image();
            }

            if(img is Image)
            {
                
                //дабавляем этот обьект в библиотеку
                ImageLibrary.Add(img) ;

                //добавляем для нее специальный загрузчик
                BitmapImages.Add(new BitmapImage());

                //добавляем путь в библиотеку путей
                Paths.Add(path);

                //инициализируем добавленный загрузчик
                BitmapImages[BitmapImages.Count - 1].BeginInit();
                //и прикручиваем к нему нужный путь
                BitmapImages[BitmapImages.Count - 1].UriSource = new Uri(path, UriKind.RelativeOrAbsolute);

                //добавляем путь
                ImageLibrary[ImageLibrary.Count - 1].Source = BitmapImages[BitmapImages.Count - 1];

                BitmapImages[BitmapImages.Count - 1].EndInit();
            }
        }



        public static ImageKeeper Init()
        {
            if(Ik == null)
            {
                Ik = new ImageKeeper();
            }
            return new ImageKeeper();
        }

        public object Clone(int i)
        {
            //требуеться вернуть клон обьекта ImageLibrary[i]
            return new Image { Source = ImageLibrary[i].Source };
        }
    }
}
