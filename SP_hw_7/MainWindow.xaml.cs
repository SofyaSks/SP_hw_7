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


namespace SP_hw_7
{
   
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task t1 = Task.Run(() => Encryte("file_1.txt", "file_2.txt"));
            Task t2 = Task.Run(() => Encryte("file_3.txt", "file_4.txt"));
            Task t3 = Task.Run(() => Encryte("file_5.txt", "file_6.txt"));
            Task t4 = Task.Run(() => Encryte("file_7.txt", "file_8.txt"));
            Task.WhenAll(t1, t2, t3, t4).ContinueWith(prev => Dispatcher.Invoke(() => progressBar.Value = 100))
                .ContinueWith(prev => MessageBox.Show("Шифровка завершена"));


        }

        private async void Encryte(string pathFrom, string pathTo)
        {
            using Stream from = File.OpenRead(pathFrom);
            using Stream to = File.OpenWrite(pathTo);

            byte[] symarr = new byte[from.Length];

         
            await from.ReadAsync(symarr, 0, symarr.Length);

            for (int i = 0; i < symarr.Length; i++)
            {
                symarr[i]++;
            }

            await to.WriteAsync(symarr, 0, symarr.Length);

        }


        /* private async void Encryte(string pathFrom*//*, string pathTo*//*)
         {
             //using Stream from = File.OpenRead(pathFrom);
             //using Stream to = File.OpenWrite(pathTo);

             using Stream file = File.Open(pathFrom, FileMode.Open, FileAccess.ReadWrite);

             byte[] symarr = new byte[file.Length];
             //progressBar.Maximum = from.Length;

             MessageBox.Show(file.Length.ToString());

             await file.ReadAsync(symarr, 0, symarr.Length);

             for (int i = 0; i < symarr.Length; i++)
             {
                 symarr[i]--;
             }

             await file.WriteAsync(symarr, 0, symarr.Length);

             *//* for (int i = 0; i < symarr.Length; i++)
              {
                  symarr[i]--;
              }

              await to.WriteAsync(symarr, 0, symarr.Length);*//*
         }
     }*/

    }
}
