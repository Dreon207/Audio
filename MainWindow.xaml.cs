using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Path = System.IO.Path;
using System.Drawing;
using Microsoft.WindowsAPICodePack.Dialogs;
using static System.Net.WebRequestMethods;
using System.Reflection;
using System.Runtime.Intrinsics.X86;

namespace Pleer
{
    

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MediaPlayer mediaPlayer = new MediaPlayer();
        public int nomplay;
        public MainWindow()
        {

            InitializeComponent();            
        }


        private void Otkr(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog { IsFolderPicker = true};           
            CommonFileDialogResult result = dialog.ShowDialog();
   
            if (result == CommonFileDialogResult.Ok)
            {

                string[] files = Directory.GetFiles(dialog.FileName);
               
                    foreach (string file in files)
                {
                    if (file.Contains("mp3") ^ file.Contains("m4a") ^ file.Contains("wav"))
                    {
                        List.Items.Add(file);
                    }

                }
            }

            Playmelodi();

        }


        void Playmelodi()
        {

                nomplay = 0;
                string file = (string)List.Items[nomplay];
                media.Source = new Uri (file);
                media.Play();
         

        }

         void Button_Click(object sender, RoutedEventArgs e)
        {
           
            int i = List.Items.Count-1;
            if (i == nomplay)
            {
                string file = (string)List.Items[nomplay];
                media.Source = new Uri(file);
                media.Play();
            }
            else
            {
                nomplay++;
                string file = (string)List.Items[nomplay];
                media.Source = new Uri(file);
                media.Play();

            }


         }

        private void audioSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Position = new TimeSpan(Convert.ToInt64(audioSlider.Value));
        }

        private void Igr(object sender, RoutedEventArgs e)
        {
           
           int off = 0;
            if ((string)Ig.Content == "Пауза")
            {
                off = 1;
                media.Pause();
                Ig.Content = "Играть";
            }

            if (((string)Ig.Content == "Играть") && off == 0)
            {
                media.Play();
                Ig.Content = "Пауза";
            }


        }

        private void media_MediaOpened(object sender, RoutedEventArgs e)
        {
           
                audioSlider.Maximum = media.NaturalDuration.TimeSpan.Ticks;
            
        }

        void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int i = List.Items.Count;
           
            if (nomplay==0)
            {
                string file = (string)List.Items[nomplay];
                media.Source = new Uri(file);
                media.Play();
            }
            else
            {
                nomplay--;
                string file = (string)List.Items[nomplay];
                media.Source = new Uri(file);
                media.Play();

            }
        }

        private void Povtor(object sender, RoutedEventArgs e)
        {
            
            if ((string)Povi.Content == "Повтор")
            {                
                media.Stop();
                Povi.Content = "Повтор ";

            }

            if ((string)Povi.Content == "Повтор ")
            {
                media.Play();
                Povi.Content = "Повтор";

            }

        }

        //private void Peremex(object sender, RoutedEventArgs e)
       // {
          //  for (int i = 0; i < files.Count; i++)
          //  {
          //      int tmp = A[0];
         //       A.RemoveAt(0);
          //      A.Insert(RND.Next(A.Count), tmp);
          //  }
       // }
    }
}
