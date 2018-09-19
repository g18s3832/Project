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
using System.IO;

namespace Rough_Project_work
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public class GameObjects
    {
        private string GetShip(int ship)
        {
            string shipname = "";
            switch(ship)
            {
                case 1:
                    shipname += Directory.GetCurrentDirectory() +"/Ships/Ship 1.png";
                    break;
                case 2:
                    shipname += Directory.GetCurrentDirectory() + "/Ships/Ship 2.png";
                    break;
                case 3:
                    shipname += Directory.GetCurrentDirectory() + "/Ships/Ship 3.png";
                    break;
                case 4:
                    shipname += Directory.GetCurrentDirectory() + "/Ships/Ship 4.png";
                    break;
            }
            return shipname;
        }
        public string Ship(int code)
        {
            return GetShip(code);
        }
        private string GetEnemy(int enemy)
        {
            string enemytype = "";
            switch(enemy)
            {
                case 1:
                    enemytype += Directory.GetCurrentDirectory() + "/Enemy/Enemy1.png";
                    break;
                case 2:
                    enemytype += Directory.GetCurrentDirectory() + "/Enemy/Enemy2.png";
                    break;
                case 3:
                    enemytype += Directory.GetCurrentDirectory() + "/Enemy/Enemy3.png";
                    break;
            }
            return enemytype;
        }
        public string Enemy(int code)
        {
            return GetEnemy(code);
        }

        
    }
    public partial class MainWindow : Window
    {
        
        string imagename = "awesome.jpg";
        string filepath = Directory.GetCurrentDirectory();
        int Cyclecount = 0;
        public MainWindow()
        {
            //mess
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Cyclecount += 1;
            if (Cyclecount == 5)
                Cyclecount = 1;
            switch (Cyclecount)
            {
                case 1:
                    imagename = "cool.jpg";
                    break;
                case 2:
                    imagename = "awesome.jpg";
                    break;
                case 3:
                    imagename = "pussy.jpg";
                        break;
                case 4:
                    imagename = "dope.jpg";
                    break;
            }
            string imagepath = filepath + @"\" + imagename;
           // MessageBox.Show(filepath);
            // Image myimage= new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this),))
            this.Background = new ImageBrush(new BitmapImage(new Uri(imagepath)));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//new game
        {
            Window1 window1 = new Window1();
            window1.Show();
            Main_Menu.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//continue
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)//options

        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)//quit game
        {

        }
       
    }
}
