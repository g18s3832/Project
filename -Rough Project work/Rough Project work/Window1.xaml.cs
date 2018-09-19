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
using System.Windows.Shapes;
using System.IO;
using System.Media;
using System.Windows.Threading;
using System.Windows.Resources;


namespace Rough_Project_work
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List <Image> Ammo = new List <Image>();
        List<Image> Enemy = new List<Image>();
        string ammo = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString()) + @"\Ammo\Blasters\Blaster1.png";
        string enemy = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString()) + @"\Enemy\Enemy1.png";
        string ammoSound = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString()) + @"\Sounds\Blasters\Blaster1.wav";
        double shipVelX = 15;
        DispatcherTimer theTimer = new DispatcherTimer();
        DispatcherTimer enemyTimer = new DispatcherTimer();
        public Window1()
        {
            InitializeComponent();
            Play.Visibility = Visibility.Hidden;
            Main_Menu_Button.Visibility = Visibility.Hidden;
            enemyTimer.Interval = TimeSpan.FromSeconds(1.5);
            enemyTimer.IsEnabled = true;
            enemyTimer.Tick += new EventHandler(enemyTimer_Tick);
            theTimer.Interval = TimeSpan.FromMilliseconds(70);
            theTimer.IsEnabled = true;
            theTimer.Tick += new EventHandler(TheTimer_Tick);   
        }
        private void enemyTimer_Tick(object sender, EventArgs e)
        {
            Enemy.Add(LoadEnemy(enemy)); 
        }
        private void BlasterSound()
        {
            //Uri SoundPath = new Uri(Directory.GetCurrentDirectory() +"\\"+ @"Sounds\Blaster1.wav");
            //StreamResourceInfo strm = Application.GetResourceStream(SoundPath);
            SoundPlayer sp = new SoundPlayer((Directory.GetCurrentDirectory() + @"\" + @"Sounds\Blasters\Blaster1.wav"));
            sp.Play();
        }
        private void TheTimer_Tick(object sender, EventArgs e)
        {

            for (int i = 0; i < Ammo.Count; i++)
            {
                updateProjectile(Ammo[i]);

            }
            for (int j = 0; j < Enemy.Count; j++)
            {
                updateEnemy(Enemy[j]);
            }
        }

        /*private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            
        }*/
        private void updateEnemy(Image ene)
        {
            double NextY = Canvas.GetTop(ene) + shipVelX;
            if (NextY <= canvas.ActualHeight-ene.ActualHeight)
            {
                Canvas.SetTop(ene, NextY);
            }
            else
            {
                canvas.Children.Remove(ene);
            }

        }
        private void updateProjectile(Image img)
        {
            double nextY = Canvas.GetTop(img) - shipVelX;
            if (nextY <= canvas.ActualHeight + img.ActualHeight)
            {
                Canvas.SetTop(img, nextY);
            }
            else
            {
                canvas.Children.Remove(img);
            }
        }
        //public void Credits() { }
        private void Window_Keydown(object sender,KeyEventArgs e)
        {
            double NextY = 0;
            double NextX = 0;
            NextX = (Canvas.GetLeft(ship));
            NextY = Canvas.GetTop(ship);
            switch(e.Key)
            {
                case Key.Left:
                    NextX -= shipVelX;
                    if (NextX < 0 || NextX + ship.ActualWidth >= canvas.ActualWidth)
                    {
                        break;
                    }
                    else
                    {
                        Canvas.SetLeft(ship, NextX);
                    }
                    break;
                case Key.Right:
                    NextX += shipVelX;
                    if (NextX < 0 || NextX + ship.ActualWidth >= canvas.ActualWidth)
                    {
                        break;
                    }
                    else
                    {
                        Canvas.SetLeft(ship, NextX);
                    }
                    break;

                case Key.Down:
                    NextY += shipVelX;
                    if (NextY < 0 || NextY + ship.ActualHeight >= canvas.ActualHeight)
                    {
                        break;
                    }
                    else
                    {
                        Canvas.SetTop(ship, NextY);
                    }
                    break;
                case Key.Up:
                    NextY -= shipVelX;
                    if (NextY < 0 || NextY + ship.ActualHeight >= canvas.ActualHeight)
                    {
                        break;
                    }
                    else
                    {
                        Canvas.SetTop(ship, NextY);
                    }
                    break;
                case Key.Escape:
                    Pause();
                    break;
                case Key.Space:
                    Ammo.Add(LoadAmmo(ammo));
                    BlasterSound();
                    TheTimer_Tick(Ammo, e);
                    break;
            }
        }
        private void Pause()
        {
            theTimer.Stop();
            Play.Visibility = Visibility.Visible;
            Main_Menu_Button.Visibility = Visibility.Visible;
        }
        private Image LoadAmmo(string ammo)
        {
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(ammo));
            img.Height = (20);
            img.Width = 10;
            canvas.Children.Add(img);
            Canvas.SetLeft(img, Canvas.GetLeft(ship) + (ship.ActualWidth / 2)-3);
            Canvas.SetTop(img, Canvas.GetTop(ship));
            return img;   
        }
        private Image LoadEnemy(string enmy)
        {
            Image enm = new Image();
            enm.Source = new BitmapImage(new Uri(enmy));
            enm.Height = 50;
            enm.Width = 45;
            Random pos = new Random();
            canvas.Children.Add(enm);
            Canvas.SetLeft(enm, pos.Next((int)enm.ActualWidth,((int)(canvas.ActualWidth)-(int)(enm.ActualWidth))));
            Canvas.SetTop(enm, 0);
            return enm;

        }
        private void Button_Click(object sender, RoutedEventArgs e)//panel
        {

        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            theTimer.Start();
            Play.Visibility = Visibility.Hidden;
            Main_Menu_Button.Visibility = Visibility.Hidden;
        }
    }
}
