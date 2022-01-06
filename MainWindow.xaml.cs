using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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

namespace Memory211221
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int clickCount;
        static Random rnd = new Random();
        private List<Button> ImageButtons = new List<Button>();
        private List<Button> SpielendeButtons = new List<Button>();
        private List<Button> backgroundVergleich = new List<Button>();
        
        private List<ImageBrush> SpielBilder = new List<ImageBrush>();
        private List<Border> AllBorders = new List<Border>();
        private List<Border> BordersImGame = new List<Border>();
        private DispatcherTimer myTimer1 = new DispatcherTimer();
        private DispatcherTimer myTimer2 = new DispatcherTimer();
        private DispatcherTimer myTimer3 = new DispatcherTimer();
        Stopwatch stopwatch = new Stopwatch();
        string AktuelleZeit = string.Empty;
        SoundPlayer winSound = new SoundPlayer(@"Resources\instantwin.wav");
        //                                        @"J:\C#Versuche\Memory211221\Resources\instantwin.wav"
        
        //static string ccode = "#FFFF7F27";
        
        static Color clr = Color.FromRgb(255,127,39);
        Brush br = new SolidColorBrush(clr);

        private int zs = 0, sek = 0, min = 0, h = 0;
        public MainWindow()
        {
            InitializeComponent();
            myTimer1.Interval = TimeSpan.FromMilliseconds(300);
            myTimer1.Tick += BilderVergleichen;

            myTimer3.Tick += new EventHandler(Timer_Tick);
            myTimer3.Interval = new TimeSpan(0,0,0,0,1);
          
        }
        
        private void SpielFeldBauen2x2(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
            stopwatch.Reset();
            stopwatch.Start();
            myTimer3.Start();
            clickCount = 0;
            ButtonsAndBorderVerstecken();
            backgroundVergleich.Clear();
            SpielendeButtons.Clear();
            BordersImGame.Clear();
            bool[] istBelegt = new bool[4];
            int a = 0, b = 0;
            for (int index = 0; index < istBelegt.Length; index++)
            {
                istBelegt[index] = false;
            }
            StartBild.Visibility = Visibility.Hidden;



            for (int index = 0; index < 1; index++)
            {
                a = rnd.Next(0, 29);
                b = rnd.Next(0, 29);
                if (a == b ||
                    b == a)
                {
                    //MessageBox.Show("Ich hier");
                    index--;
                }
            }
            #region Image Buttons Border
            ImageBrush aimg = SpielBilder[a];
            ImageBrush bimg = SpielBilder[b];
            ImageBrush cimg = SpielBilder[a];
            ImageBrush dimg = SpielBilder[b];

            SpielendeButtons.Add(ImageButtons[0]);
            SpielendeButtons.Add(ImageButtons[1]);
            SpielendeButtons.Add(ImageButtons[5]);
            SpielendeButtons.Add(ImageButtons[6]);
            BordersImGame.Add(AllBorders[0]);
            BordersImGame.Add(AllBorders[1]);
            BordersImGame.Add(AllBorders[5]);
            BordersImGame.Add(AllBorders[6]);

            #endregion
            HintergrundFarbe();
            
            
            for (int i = 0; i < 4; i++)
            {
                SpielendeButtons[i].Visibility = Visibility.Visible;
                BordersImGame[i].Visibility = Visibility.Visible;
                SpielendeButtons[i].Opacity = 0;
                SpielendeButtons[i].Click += SpielendeButtons_Click;
                SpielendeButtons[i].IsEnabled = true;
            }
            #region BilderZuweisen
            for (int i = 0; i < 1; i++)
            {
                int c = rnd.Next(0, 4);
                if (!istBelegt[c] && SpielendeButtons[c].Background != aimg)
                {
                    SpielendeButtons[c].Background = aimg;                
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[c] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int c = rnd.Next(0, 4);
                if (!istBelegt[c] && SpielendeButtons[c].Background != bimg)
                {
                    SpielendeButtons[c].Background = bimg;  
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[c] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int c = rnd.Next(0, 4);
                if (!istBelegt[c] && SpielendeButtons[c].Background != cimg)
                {
                    SpielendeButtons[c].Background = cimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[c] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int c = rnd.Next(0, 4);
                if (!istBelegt[c] && SpielendeButtons[c].Background != dimg)
                {
                    SpielendeButtons[c].Background = dimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[c] = true;
            }
            #endregion         
            TextChangedEventArgs tceargs = e as TextChangedEventArgs;
            Anzeige(sender, tceargs);
        }
        private void SpielFeldBauen2x3(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
            stopwatch.Reset();
            stopwatch.Start();
            myTimer3.Start();
            clickCount = 0;
            ButtonsAndBorderVerstecken();
            backgroundVergleich.Clear();
            SpielendeButtons.Clear();
            BordersImGame.Clear();
            bool[] istBelegt = new bool[6];
            int a = 0, b = 0, c = 0;
            for (int index = 0; index < istBelegt.Length; index++)
            {
                istBelegt[index] = false;
            }
            StartBild.Visibility = Visibility.Hidden;
            for (int index = 0; index < 1; index++)
            {
                a = rnd.Next(0, 29);
                b = rnd.Next(0, 29);
                c = rnd.Next(0, 29);              
                if     (a == b || a == c || 
                        b == a || b == c ||
                        c == a || c == b)
                {
                    //MessageBox.Show("Ich hier");
                    index--;
                }
            }
            #region Image Buttons Border
            ImageBrush aimg = SpielBilder[a];
            ImageBrush bimg = SpielBilder[b];
            ImageBrush cimg = SpielBilder[c];
            ImageBrush dimg = SpielBilder[a];
            ImageBrush eimg = SpielBilder[b];
            ImageBrush fimg = SpielBilder[c];

            SpielendeButtons.Add(ImageButtons[0]);
            SpielendeButtons.Add(ImageButtons[1]);
            SpielendeButtons.Add(ImageButtons[2]);
            SpielendeButtons.Add(ImageButtons[5]);
            SpielendeButtons.Add(ImageButtons[6]);
            SpielendeButtons.Add(ImageButtons[7]);
            BordersImGame.Add(AllBorders[0]);
            BordersImGame.Add(AllBorders[1]);
            BordersImGame.Add(AllBorders[2]);
            BordersImGame.Add(AllBorders[5]);
            BordersImGame.Add(AllBorders[6]);
            BordersImGame.Add(AllBorders[7]);
            #endregion
            HintergrundFarbe();
            for (int i = 0; i < 6; i++)
            {
                SpielendeButtons[i].Visibility = Visibility.Visible;
                BordersImGame[i].Visibility = Visibility.Visible;
                SpielendeButtons[i].Opacity = 0;
                SpielendeButtons[i].Click += SpielendeButtons_Click;
                SpielendeButtons[i].IsEnabled = true;
            }
            #region BilderZuweisen
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 6);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != aimg)
                {
                    SpielendeButtons[imBool].Background = aimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 6);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != bimg)
                {
                    SpielendeButtons[imBool].Background = bimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 6);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != cimg)
                {
                    SpielendeButtons[imBool].Background = cimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 6);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != dimg)
                {
                    SpielendeButtons[imBool].Background = dimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 6);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != eimg)
                {
                    SpielendeButtons[imBool].Background = eimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 6);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != fimg)
                {
                    SpielendeButtons[imBool].Background = fimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            #endregion
            TextChangedEventArgs tceargs = e as TextChangedEventArgs;
            Anzeige(sender, tceargs);

        }
        private void SpielFeldBauen2x4(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
            stopwatch.Reset();
            stopwatch.Start();
            myTimer3.Start();
            clickCount = 0;
            ButtonsAndBorderVerstecken();
            backgroundVergleich.Clear();
            SpielendeButtons.Clear();
            BordersImGame.Clear();
            bool[] istBelegt = new bool[8];
            int a = 0, b = 0, c = 0, d = 0;
            for (int index = 0; index < istBelegt.Length; index++)
            {
                istBelegt[index] = false;
            }
            StartBild.Visibility = Visibility.Hidden;
            for (int index = 0; index < 1; index++)
            {
                a = rnd.Next(0, 29);
                b = rnd.Next(0, 29);
                c = rnd.Next(0, 29);
                d = rnd.Next(0, 29);               
                if     (a == b || a == c || a == d || 
                        b == a || b == c || b == d ||
                        c == a || c == b || c == d || 
                        d == a || d == b || d == c)
                {
                    //MessageBox.Show("Ich hier");
                    index--;
                }
            }
            #region Image Buttons Border
            ImageBrush aimg = SpielBilder[a];
            ImageBrush bimg = SpielBilder[b];
            ImageBrush cimg = SpielBilder[c];
            ImageBrush dimg = SpielBilder[d];
            ImageBrush eimg = SpielBilder[a];
            ImageBrush fimg = SpielBilder[b];
            ImageBrush gimg = SpielBilder[c];
            ImageBrush himg = SpielBilder[d];

            SpielendeButtons.Add(ImageButtons[0]);
            SpielendeButtons.Add(ImageButtons[1]);
            SpielendeButtons.Add(ImageButtons[2]);
            SpielendeButtons.Add(ImageButtons[3]);
            SpielendeButtons.Add(ImageButtons[5]);
            SpielendeButtons.Add(ImageButtons[6]);
            SpielendeButtons.Add(ImageButtons[7]);
            SpielendeButtons.Add(ImageButtons[8]);
            BordersImGame.Add(AllBorders[0]);
            BordersImGame.Add(AllBorders[1]);
            BordersImGame.Add(AllBorders[2]);
            BordersImGame.Add(AllBorders[3]);
            BordersImGame.Add(AllBorders[5]);
            BordersImGame.Add(AllBorders[6]);
            BordersImGame.Add(AllBorders[7]);
            BordersImGame.Add(AllBorders[8]);
            #endregion
            HintergrundFarbe();
            for (int i = 0; i < 8; i++)
            {
                SpielendeButtons[i].Visibility = Visibility.Visible;
                BordersImGame[i].Visibility = Visibility.Visible;
                SpielendeButtons[i].Opacity = 0;
                SpielendeButtons[i].Click += SpielendeButtons_Click;
                SpielendeButtons[i].IsEnabled = true;
            }
            #region BilderZuweisen
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 8);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != aimg)
                {
                    SpielendeButtons[imBool].Background = aimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 8);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != bimg)
                {
                    SpielendeButtons[imBool].Background = bimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 8);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != cimg)
                {
                    SpielendeButtons[imBool].Background = cimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 8);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != dimg)
                {
                    SpielendeButtons[imBool].Background = dimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 8);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != eimg)
                {
                    SpielendeButtons[imBool].Background = eimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 8);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != fimg)
                {
                    SpielendeButtons[imBool].Background = fimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 8);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != gimg)
                {
                    SpielendeButtons[imBool].Background = gimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 8);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != himg)
                {
                    SpielendeButtons[imBool].Background = himg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            #endregion
            TextChangedEventArgs tceargs = e as TextChangedEventArgs;
            Anzeige(sender, tceargs);

        }
        private void SpielFeldBauen3x4(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
            stopwatch.Reset();
            stopwatch.Start();
            myTimer3.Start();
            clickCount = 0;
            ButtonsAndBorderVerstecken();
            backgroundVergleich.Clear();
            SpielendeButtons.Clear();
            BordersImGame.Clear();
            bool[] istBelegt = new bool[12];
            int a = 0, b = 0, c = 0, d = 0, f = 0, g = 0;
            for (int index = 0; index < istBelegt.Length; index++)
            {
                istBelegt[index] = false;
            }
            StartBild.Visibility = Visibility.Hidden;
            for (int index = 0; index < 1; index++)
            {
                a = rnd.Next(0, 29);
                b = rnd.Next(0, 29);
                c = rnd.Next(0, 29);
                d = rnd.Next(0, 29);
                f = rnd.Next(0, 29);
                g = rnd.Next(0, 29);
                

                if (a == b || a == c || a == d || a == f || a == g || 
                        b == a || b == c || b == d || b == f || b == g || 
                        c == a || c == b || c == d || c == f || c == g || 
                        d == a || d == b || d == c || d == f || d == g || 
                        f == a || f == b || f == c || f == d || f == g || 
                        g == a || g == b || g == c || g == d || g == f || 
                        g == a || g == b || g == c || g == d || g == f )
                {
                    //MessageBox.Show("Ich hier");
                    index--;
                }
            }
            #region Image Buttons Border
            ImageBrush aimg = SpielBilder[a];
            ImageBrush bimg = SpielBilder[b];
            ImageBrush cimg = SpielBilder[c];
            ImageBrush dimg = SpielBilder[d];
            ImageBrush eimg = SpielBilder[f];
            ImageBrush fimg = SpielBilder[g];
            ImageBrush gimg = SpielBilder[a];
            ImageBrush himg = SpielBilder[b];
            ImageBrush iimg = SpielBilder[c];
            ImageBrush jimg = SpielBilder[d];
            ImageBrush kimg = SpielBilder[f];
            ImageBrush limg = SpielBilder[g];

            SpielendeButtons.Add(ImageButtons[0]);
            SpielendeButtons.Add(ImageButtons[1]);
            SpielendeButtons.Add(ImageButtons[2]);
            SpielendeButtons.Add(ImageButtons[3]);
            SpielendeButtons.Add(ImageButtons[5]);
            SpielendeButtons.Add(ImageButtons[6]);
            SpielendeButtons.Add(ImageButtons[7]);
            SpielendeButtons.Add(ImageButtons[8]);
            SpielendeButtons.Add(ImageButtons[10]);
            SpielendeButtons.Add(ImageButtons[11]);
            SpielendeButtons.Add(ImageButtons[12]);
            SpielendeButtons.Add(ImageButtons[13]);
            BordersImGame.Add(AllBorders[0]);
            BordersImGame.Add(AllBorders[1]);
            BordersImGame.Add(AllBorders[2]);
            BordersImGame.Add(AllBorders[3]);
            BordersImGame.Add(AllBorders[5]);
            BordersImGame.Add(AllBorders[6]);
            BordersImGame.Add(AllBorders[7]);
            BordersImGame.Add(AllBorders[8]);
            BordersImGame.Add(AllBorders[10]);
            BordersImGame.Add(AllBorders[11]);
            BordersImGame.Add(AllBorders[12]);
            BordersImGame.Add(AllBorders[13]);
            #endregion
            HintergrundFarbe();
            for (int i = 0; i < 12; i++)
            {
                SpielendeButtons[i].Visibility = Visibility.Visible;
                BordersImGame[i].Visibility = Visibility.Visible;
                SpielendeButtons[i].Opacity = 0;
                SpielendeButtons[i].Click += SpielendeButtons_Click;
                SpielendeButtons[i].IsEnabled = true;
            }
            #region BilderZuweisen
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 12);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != aimg)
                {
                    SpielendeButtons[imBool].Background = aimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 12);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != bimg)
                {
                    SpielendeButtons[imBool].Background = bimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 12);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != cimg)
                {
                    SpielendeButtons[imBool].Background = cimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 12);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != dimg)
                {
                    SpielendeButtons[imBool].Background = dimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 12);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != eimg)
                {
                    SpielendeButtons[imBool].Background = eimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 12);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != fimg)
                {
                    SpielendeButtons[imBool].Background = fimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 12);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != gimg)
                {
                    SpielendeButtons[imBool].Background = gimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 12);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != himg)
                {
                    SpielendeButtons[imBool].Background = himg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 12);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != iimg)
                {
                    SpielendeButtons[imBool].Background = iimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 12);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != jimg)
                {
                    SpielendeButtons[imBool].Background = jimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 12);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != kimg)
                {
                    SpielendeButtons[imBool].Background = kimg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int i = 0; i < 1; i++)
            {
                int imBool = rnd.Next(0, 12);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != limg)
                {
                    SpielendeButtons[imBool].Background = limg;
                }
                else
                {
                    i--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            #endregion
            TextChangedEventArgs tceargs = e as TextChangedEventArgs;
            Anzeige(sender, tceargs);

        }
        private void SpielFeldBauen4x4(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
            stopwatch.Reset();
            stopwatch.Start();
            myTimer3.Start();
            clickCount = 0;
            ButtonsAndBorderVerstecken();
            backgroundVergleich.Clear();
            SpielendeButtons.Clear();
            BordersImGame.Clear();
            bool[] istBelegt = new bool[16];
            int a = 0, b = 0, c = 0, d = 0, f = 0, g = 0, h = 0, i = 0;
            for (int index = 0; index < istBelegt.Length; index++)
            {
                istBelegt[index] = false;
            }
            
            StartBild.Visibility = Visibility.Hidden;
            for (int index = 0; index < 1; index++)
            {
                a = rnd.Next(0, 29);
                b = rnd.Next(0, 29);
                c = rnd.Next(0, 29);
                d = rnd.Next(0, 29);
                f = rnd.Next(0, 29);
                g = rnd.Next(0, 29);
                h = rnd.Next(0, 29);
                i = rnd.Next(0, 29);
                
            if     (a == b || a == c || a == d || a == f || a == g || a == h || a == i || 
                    b == a || b == c || b == d || b == f || b == g || b == h || b == i ||
                    c == a || c == b || c == d || c == f || c == g || c == h || c == i ||
                    d == a || d == b || d == c || d == f || d == g || d == h || d == i || 
                    f == a || f == b || f == c || f == d || f == g || f == h || f == i || 
                    g == a || g == b || g == c || g == d || g == f || g == h || g == i || 
                    g == a || g == b || g == c || g == d || g == f || g == h || g == i || 
                    h == a || h == b || h == c || h == d || h == f || h == g || h == i || 
                    i == a || i == b || i == c || i == d || i == f || i == g || i == h  )
                {
                    //MessageBox.Show("Ich hier");
                    index--;
                }
            }
            #region Image Buttons Border
            ImageBrush aimg = SpielBilder[a];
            ImageBrush bimg = SpielBilder[b];
            ImageBrush cimg = SpielBilder[c];
            ImageBrush dimg = SpielBilder[d];
            ImageBrush eimg = SpielBilder[f];
            ImageBrush fimg = SpielBilder[g];
            ImageBrush gimg = SpielBilder[h];
            ImageBrush himg = SpielBilder[i];
            ImageBrush iimg = SpielBilder[a];
            ImageBrush jimg = SpielBilder[b];
            ImageBrush kimg = SpielBilder[c];
            ImageBrush limg = SpielBilder[d];
            ImageBrush mimg = SpielBilder[f];
            ImageBrush nimg = SpielBilder[g];
            ImageBrush oimg = SpielBilder[h];
            ImageBrush pimg = SpielBilder[i];

            SpielendeButtons.Add(ImageButtons[0]);
            SpielendeButtons.Add(ImageButtons[1]);
            SpielendeButtons.Add(ImageButtons[2]);
            SpielendeButtons.Add(ImageButtons[3]);
            SpielendeButtons.Add(ImageButtons[5]);
            SpielendeButtons.Add(ImageButtons[6]);
            SpielendeButtons.Add(ImageButtons[7]);
            SpielendeButtons.Add(ImageButtons[8]);
            SpielendeButtons.Add(ImageButtons[10]);
            SpielendeButtons.Add(ImageButtons[11]);
            SpielendeButtons.Add(ImageButtons[12]);
            SpielendeButtons.Add(ImageButtons[13]);
            SpielendeButtons.Add(ImageButtons[15]);
            SpielendeButtons.Add(ImageButtons[16]);
            SpielendeButtons.Add(ImageButtons[17]);
            SpielendeButtons.Add(ImageButtons[18]);
            BordersImGame.Add(AllBorders[0]);
            BordersImGame.Add(AllBorders[1]);
            BordersImGame.Add(AllBorders[2]);
            BordersImGame.Add(AllBorders[3]);
            BordersImGame.Add(AllBorders[5]);
            BordersImGame.Add(AllBorders[6]);
            BordersImGame.Add(AllBorders[7]);
            BordersImGame.Add(AllBorders[8]);
            BordersImGame.Add(AllBorders[10]);
            BordersImGame.Add(AllBorders[11]);
            BordersImGame.Add(AllBorders[12]);
            BordersImGame.Add(AllBorders[13]);
            BordersImGame.Add(AllBorders[15]);
            BordersImGame.Add(AllBorders[16]);
            BordersImGame.Add(AllBorders[17]);
            BordersImGame.Add(AllBorders[18]);
            #endregion
            HintergrundFarbe();
            for (int index = 0; index < 16; index++)
            {
                SpielendeButtons[index].Visibility = Visibility.Visible;
                BordersImGame[index].Visibility = Visibility.Visible;
                SpielendeButtons[index].Opacity = 0;
                SpielendeButtons[index].Click += SpielendeButtons_Click;
                SpielendeButtons[index].IsEnabled = true;
            }
            #region BilderZuweisen
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 16);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != aimg)
                {
                    SpielendeButtons[imBool].Background = aimg;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 16);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != bimg)
                {
                    SpielendeButtons[imBool].Background = bimg;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 16);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != cimg)
                {
                    SpielendeButtons[imBool].Background = cimg;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 16);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != dimg)
                {
                    SpielendeButtons[imBool].Background = dimg;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 16);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != eimg)
                {
                    SpielendeButtons[imBool].Background = eimg;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 16);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != fimg)
                {
                    SpielendeButtons[imBool].Background = fimg;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 16);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != gimg)
                {
                    SpielendeButtons[imBool].Background = gimg;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 16);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != himg)
                {
                    SpielendeButtons[imBool].Background = himg;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 16);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != iimg)
                {
                    SpielendeButtons[imBool].Background = iimg;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 16);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != jimg)
                {
                    SpielendeButtons[imBool].Background = jimg;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 16);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != kimg)
                {
                    SpielendeButtons[imBool].Background = kimg;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 16);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != limg)
                {
                    SpielendeButtons[imBool].Background = limg;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 16);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != mimg)
                {
                    SpielendeButtons[imBool].Background = mimg;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 16);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != nimg)
                {
                    SpielendeButtons[imBool].Background = nimg;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 16);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != oimg)
                {
                    SpielendeButtons[imBool].Background = oimg;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 16);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != pimg)
                {
                    SpielendeButtons[imBool].Background = pimg;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            #endregion
            TextChangedEventArgs tceargs = e as TextChangedEventArgs;
            Anzeige(sender, tceargs);

        }
        private void SpielFeldBauen5x2(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
            stopwatch.Reset();
            stopwatch.Start();
            myTimer3.Start();
            clickCount = 0;
            ButtonsAndBorderVerstecken();
            backgroundVergleich.Clear();
            SpielendeButtons.Clear();
            BordersImGame.Clear();
            bool[] istBelegt = new bool[10];
            int a = 0, b = 0, c = 0, d = 0, f = 0;
            for (int index = 0; index < istBelegt.Length; index++)
            {
                istBelegt[index] = false;
            }

            StartBild.Visibility = Visibility.Hidden;
            for (int index = 0; index < 1; index++)
            {
                a = rnd.Next(0, 29);
                b = rnd.Next(0, 29);
                c = rnd.Next(0, 29);
                d = rnd.Next(0, 29);
                f = rnd.Next(0, 29);
               
                if (a == b || a == c || a == d || a == f || 
                        b == a || b == c || b == d || b == f || 
                        c == a || c == b || c == d || c == f || 
                        d == a || d == b || d == c || d == f || 
                        f == a || f == b || f == c || f == d 
                       )
                {
                    //MessageBox.Show("Ich hier");
                    index--;
                }
            }


            #region Image Buttons Border
            ImageBrush img1 = SpielBilder[a];
            ImageBrush img2 = SpielBilder[b];
            ImageBrush img3 = SpielBilder[c];
            ImageBrush img4 = SpielBilder[d];
            ImageBrush img5 = SpielBilder[f];
            ImageBrush img6 = SpielBilder[a];
            ImageBrush img7 = SpielBilder[b];
            ImageBrush img8 = SpielBilder[c];
            ImageBrush img9 = SpielBilder[d];
            ImageBrush img10 = SpielBilder[f];

            SpielendeButtons.Add(ImageButtons[0]);
            SpielendeButtons.Add(ImageButtons[1]);
            SpielendeButtons.Add(ImageButtons[5]);
            SpielendeButtons.Add(ImageButtons[6]);
            SpielendeButtons.Add(ImageButtons[10]);
            SpielendeButtons.Add(ImageButtons[11]);
            SpielendeButtons.Add(ImageButtons[15]);
            SpielendeButtons.Add(ImageButtons[16]);
            SpielendeButtons.Add(ImageButtons[20]);
            SpielendeButtons.Add(ImageButtons[21]);
            
            BordersImGame.Add(AllBorders[0]);
            BordersImGame.Add(AllBorders[1]);
            BordersImGame.Add(AllBorders[5]);
            BordersImGame.Add(AllBorders[6]);
            BordersImGame.Add(AllBorders[10]);
            BordersImGame.Add(AllBorders[11]);
            BordersImGame.Add(AllBorders[15]);
            BordersImGame.Add(AllBorders[16]);
            BordersImGame.Add(AllBorders[20]);
            BordersImGame.Add(AllBorders[21]);
            #endregion
            HintergrundFarbe();
            for (int index = 0; index < 10; index++)
            {
                SpielendeButtons[index].Visibility = Visibility.Visible;
                BordersImGame[index].Visibility = Visibility.Visible;
                SpielendeButtons[index].Opacity = 0;
                SpielendeButtons[index].Click += SpielendeButtons_Click;
                SpielendeButtons[index].IsEnabled = true;
            }
            #region BilderZuweisen
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 10);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img1)
                {
                    SpielendeButtons[imBool].Background = img1;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 10);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img2)
                {
                    SpielendeButtons[imBool].Background = img2;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 10);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img3)
                {
                    SpielendeButtons[imBool].Background = img3;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 10);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img4)
                {
                    SpielendeButtons[imBool].Background = img4;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 10);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img5)
                {
                    SpielendeButtons[imBool].Background = img5;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 10);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img6)
                {
                    SpielendeButtons[imBool].Background = img6;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 10);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img7)
                {
                    SpielendeButtons[imBool].Background = img7;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 10);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img8)
                {
                    SpielendeButtons[imBool].Background = img8;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 10);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img9)
                {
                    SpielendeButtons[imBool].Background = img9;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 10);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img10)
                {
                    SpielendeButtons[imBool].Background = img10;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }

            #endregion
            TextChangedEventArgs tceargs = e as TextChangedEventArgs;
            Anzeige(sender, tceargs);

        }
        private void SpielFeldBauen5x4(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
            stopwatch.Reset();
            stopwatch.Start();
            myTimer3.Start();
            clickCount = 0;
            ButtonsAndBorderVerstecken();
            backgroundVergleich.Clear();
            SpielendeButtons.Clear();
            BordersImGame.Clear();
            bool[] istBelegt = new bool[20];
            int a = 0, b = 0, c = 0, d = 0, f = 0, g = 0, h = 0, i = 0, j = 0, k = 0;
            for (int index = 0; index < istBelegt.Length; index++)
            {
                istBelegt[index] = false;
            }
            StartBild.Visibility = Visibility.Hidden;          
            for (int index = 0; index < 1; index++)
            {
                a = rnd.Next(0, 29);
                b = rnd.Next(0, 29);
                c = rnd.Next(0, 29);
                d = rnd.Next(0, 29);
                f = rnd.Next(0, 29);
                g = rnd.Next(0, 29);
                h = rnd.Next(0, 29);
                i = rnd.Next(0, 29);
                j = rnd.Next(0, 29);
                k = rnd.Next(0, 29);
                if     (a == b || a == c || a == d || a == f || a == g || a == h || a == i || a == j || a == k ||
                        b == a || b == c || b == d || b == f || b == g || b == h || b == i || b == j || b == k ||
                        c == a || c == b || c == d || c == f || c == g || c == h || c == i || c == j || c == k ||
                        d == a || d == b || d == c || d == f || d == g || d == h || d == i || d == j || d == k ||
                        f == a || f == b || f == c || f == d || f == g || f == h || f == i || f == j || f == k ||
                        g == a || g == b || g == c || g == d || g == f || g == h || g == i || g == j || g == k ||
                        g == a || g == b || g == c || g == d || g == f || g == h || g == i || g == j || g == k ||
                        h == a || h == b || h == c || h == d || h == f || h == g || h == i || h == j || h == k ||
                        i == a || i == b || i == c || i == d || i == f || i == g || i == h || i == j || i == k ||
                        j == a || j == b || j == c || j == d || j == f || j == g || j == h || j == i || j == k ||
                        k == a || k == b || k == c || k == d || k == f || k == g || k == h || k == i || k == j)
                {
                    //MessageBox.Show("Ich hier");
                    index--;
                }
            }
            #region Image Buttons Border
            ImageBrush img1 = SpielBilder[a];
            ImageBrush img2 = SpielBilder[b];
            ImageBrush img3 = SpielBilder[c];
            ImageBrush img4 = SpielBilder[d];
            ImageBrush img5 = SpielBilder[f];
            ImageBrush img6 = SpielBilder[g];
            ImageBrush img7 = SpielBilder[h];
            ImageBrush img8 = SpielBilder[i];
            ImageBrush img9 = SpielBilder[j];
            ImageBrush img10 = SpielBilder[k];
            ImageBrush img11 = SpielBilder[a];
            ImageBrush img12 = SpielBilder[b];
            ImageBrush img13 = SpielBilder[c];
            ImageBrush img14 = SpielBilder[d];
            ImageBrush img15 = SpielBilder[f];
            ImageBrush img16 = SpielBilder[g];
            ImageBrush img17 = SpielBilder[h];
            ImageBrush img18 = SpielBilder[i];
            ImageBrush img19 = SpielBilder[j];
            ImageBrush img20 = SpielBilder[k];

            SpielendeButtons.Add(ImageButtons[0]);
            SpielendeButtons.Add(ImageButtons[1]);
            SpielendeButtons.Add(ImageButtons[2]);
            SpielendeButtons.Add(ImageButtons[3]);
            SpielendeButtons.Add(ImageButtons[5]);
            SpielendeButtons.Add(ImageButtons[6]);
            SpielendeButtons.Add(ImageButtons[7]);
            SpielendeButtons.Add(ImageButtons[8]);
            SpielendeButtons.Add(ImageButtons[10]);
            SpielendeButtons.Add(ImageButtons[11]);
            SpielendeButtons.Add(ImageButtons[12]);
            SpielendeButtons.Add(ImageButtons[13]);
            SpielendeButtons.Add(ImageButtons[15]);
            SpielendeButtons.Add(ImageButtons[16]);
            SpielendeButtons.Add(ImageButtons[17]);
            SpielendeButtons.Add(ImageButtons[18]);
            SpielendeButtons.Add(ImageButtons[20]);
            SpielendeButtons.Add(ImageButtons[21]);
            SpielendeButtons.Add(ImageButtons[22]);
            SpielendeButtons.Add(ImageButtons[23]);

            BordersImGame.Add(AllBorders[0]);
            BordersImGame.Add(AllBorders[1]);
            BordersImGame.Add(AllBorders[2]);
            BordersImGame.Add(AllBorders[3]);
            BordersImGame.Add(AllBorders[5]);
            BordersImGame.Add(AllBorders[6]);
            BordersImGame.Add(AllBorders[7]);
            BordersImGame.Add(AllBorders[8]);
            BordersImGame.Add(AllBorders[10]);
            BordersImGame.Add(AllBorders[11]);
            BordersImGame.Add(AllBorders[12]);
            BordersImGame.Add(AllBorders[13]);
            BordersImGame.Add(AllBorders[15]);
            BordersImGame.Add(AllBorders[16]);
            BordersImGame.Add(AllBorders[17]);
            BordersImGame.Add(AllBorders[18]);
            BordersImGame.Add(AllBorders[20]);
            BordersImGame.Add(AllBorders[21]);
            BordersImGame.Add(AllBorders[22]);
            BordersImGame.Add(AllBorders[23]);
            #endregion
            HintergrundFarbe();
            for (int index = 0; index < 20; index++)
            {
                SpielendeButtons[index].Visibility = Visibility.Visible;
                BordersImGame[index].Visibility = Visibility.Visible;
                SpielendeButtons[index].Opacity = 0;
                SpielendeButtons[index].Click += SpielendeButtons_Click;
                SpielendeButtons[index].IsEnabled = true;
            }
            #region BilderZuweisen
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 20);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img1)
                {
                    SpielendeButtons[imBool].Background = img1;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 20);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img2)
                {
                    SpielendeButtons[imBool].Background = img2;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 20);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img3)
                {
                    SpielendeButtons[imBool].Background = img3;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 20);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img4)
                {
                    SpielendeButtons[imBool].Background = img4;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 20);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img5)
                {
                    SpielendeButtons[imBool].Background = img5;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 20);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img6)
                {
                    SpielendeButtons[imBool].Background = img6;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 20);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img7)
                {
                    SpielendeButtons[imBool].Background = img7;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 20);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img8)
                {
                    SpielendeButtons[imBool].Background = img8;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 20);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img9)
                {
                    SpielendeButtons[imBool].Background = img9;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 20);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img10)
                {
                    SpielendeButtons[imBool].Background = img10;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 20);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img1)
                {
                    SpielendeButtons[imBool].Background = img1;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 20);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img2)
                {
                    SpielendeButtons[imBool].Background = img2;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 20);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img3)
                {
                    SpielendeButtons[imBool].Background = img3;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 20);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img4)
                {
                    SpielendeButtons[imBool].Background = img4;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 20);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img5)
                {
                    SpielendeButtons[imBool].Background = img5;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 20);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img6)
                {
                    SpielendeButtons[imBool].Background = img6;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 20);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img7)
                {
                    SpielendeButtons[imBool].Background = img7;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 20);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img8)
                {
                    SpielendeButtons[imBool].Background = img8;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 20);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img9)
                {
                    SpielendeButtons[imBool].Background = img9;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            for (int index = 0; index < 1; index++)
            {
                int imBool = rnd.Next(0, 20);
                if (!istBelegt[imBool] && SpielendeButtons[imBool].Background != img10)
                {
                    SpielendeButtons[imBool].Background = img10;
                }
                else
                {
                    index--;
                    continue;
                }
                istBelegt[imBool] = true;
            }
            #endregion
            TextChangedEventArgs tceargs = e as TextChangedEventArgs;
            Anzeige(sender, tceargs);
        }
        public void HintergrundFarbe()
        {
            BordersImGame.Add(AllBorders[4]);
            foreach (Border brd in AllBorders)
            {
                if (BordersImGame.Contains(brd) == false)
                {
                    brd.Background = br;
                    brd.Visibility = Visibility.Visible;
                    brd.BorderBrush = br;
                }
            }

        }
        private void SpielendeButtons_Click(object sender, RoutedEventArgs e)
        {
            clickCount++;
            TextChangedEventArgs tceargs = e as TextChangedEventArgs;
            Anzeige(sender, tceargs);
            Button a = sender as Button;
            if (a == null || a.Opacity == 100)
                return;
           
            if (backgroundVergleich.Count < 2)
            {
                backgroundVergleich.Add(a);
                a.Opacity = 100;
            }
            if (backgroundVergleich.Count == 2)
            {
                ButtonClickWEG();
                myTimer1.Start();
            }

        }
        private void BilderVergleichen(object sender, EventArgs e)
        {
            if (backgroundVergleich.Count == 2)
            {
                if (backgroundVergleich[0].Background == backgroundVergleich[1].Background)
                {
                    //MessageBox.Show("gleich");
                    SpielendeButtons.Remove(backgroundVergleich[0]);
                    SpielendeButtons.Remove(backgroundVergleich[1]);
                    backgroundVergleich.Clear();                  
                    ButtonClickGeben();
                }
                else
                {
                    backgroundVergleich[0].Opacity = 0;
                    backgroundVergleich[1].Opacity = 0;
                    ButtonClickGeben();
                    backgroundVergleich.Clear();                   
                }
                if (SpielendeButtons.Count==0)
                {                  
                    stopwatch.Stop();
                    stopwatch.Reset();                
                    winSound.Play();
                    MessageBox.Show("Du hast es drauf!!! 💪🏻😁", "Gratuliere!!!🎉🎉🎉");    
                }
                backgroundVergleich.Clear();
            }
        }
        private void ButtonClickWEG() 
        {
            foreach (Button btn in SpielendeButtons)
            {
                btn.IsEnabled = false;
                btn.Click -= SpielendeButtons_Click;
            }
        }
        private void ButtonClickGeben()
        {           
            foreach (Button btn in SpielendeButtons)
            {
                btn.IsEnabled = true;
                btn.Click += SpielendeButtons_Click;
            }
        }
       
        private void Anzeige(object sender, TextChangedEventArgs e)
        {

            tBox1_TextChanged(sender, e);
            
            
        }
        private void tBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            //tBox1.Text = $"Clicks: " + clickCount.ToString() + "\n\n" + (h) + " : " + (min) + " : " + (sek) + " : " +  (zs);
            tBox1.Text = $"Clicks: " + clickCount.ToString() + "\n\n" + AktuelleZeit;



        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                TimeSpan ts = stopwatch.Elapsed;
                AktuelleZeit = string.Format("{0:00}:{1:00}:{2:00}",ts.Minutes,ts.Seconds,ts.Milliseconds / 10);
                tBox1.Text += AktuelleZeit;
            }
           // zs++;
           // if (zs==10)
           // {
           //     sek++;
           //     zs = 0;
           // }
           // if(sek == 60)
           // {
           //     min++;
           //     sek = 0;
           // }
           //if(min == 60)
           // {
           //     min = 0;
           //     h++;
           // }
           // if(h==24)
           // {
           //     h=0;
           // }
           // tBox1.Text = (h) + " : " + (min) + " : " + (sek) + " : " + (zs);
        }
        private void Bilder()
        {
            BitmapImage[] bmpimgs = new BitmapImage[]
            {
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_01_t.PNG", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_02_t.png", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_03_t.PNG", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_04_t.PNG", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_05_t.png", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_06_t.png", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_07_t.png", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_08_t.png", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_09_t.png", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_10_t.png", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_11_t.png", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_12_t.PNG", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_13_t.PNG", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_14_t.png", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_15_t.png", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_16_t.png", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_17_t.png", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_18_t.png", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_19_t.PNG", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_20_t.PNG", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_21_t.png", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_22_t.PNG", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_23_t.PNG", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_24_t.PNG", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_25_t.png", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_27_t.png", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_28_t.png", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_29_t.png", UriKind.Relative)),
                    new BitmapImage(new Uri("Resources/BagsAndBoxes_30_t.png", UriKind.Relative))
        };
            for (int i = 0; i < 29; i++)
            {
                SpielBilder.Add(new ImageBrush());
                SpielBilder[i].ImageSource = bmpimgs[i];
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string name1;
            string name2;
            for (int j = 0; j < 25; j++)
            {
                name1 = "b" + j;
                name2 = "border" + j;
                object a = myGrid.FindName(name1);
                object b = myGrid.FindName(name2);
                ImageButtons.Add(_ = a as Button);
                AllBorders.Add(_ = b as Border);
            }
            ButtonsAndBorderVerstecken();
            Bilder();

        }
        private void ButtonsAndBorderVerstecken()
        {
            foreach (Button btns in ImageButtons)
            {
                btns.Visibility = Visibility.Hidden;


            }
            foreach (Border brd in AllBorders)
            {
                brd.Visibility = Visibility.Hidden;  
                brd.Background = null;
                brd.BorderBrush = Brushes.Black;
            }
        }

        private void Aufdecken_Click(object sender, RoutedEventArgs e)
        {
            if (SpielendeButtons.Count != 0)
            {
                foreach (Button btn in SpielendeButtons)
                {
                    btn.Opacity = 100;
                }
                myTimer2.Interval = TimeSpan.FromMilliseconds(1000);
                myTimer2.Tick += Zudecken;
                myTimer2.Start();
            }
        }
        private void Zudecken(object sender, EventArgs e)
        {
            foreach (Button btn in SpielendeButtons)
            {
                btn.Opacity = 0;
            }
            myTimer2.Stop();
        }
        private void Schliessen(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}
