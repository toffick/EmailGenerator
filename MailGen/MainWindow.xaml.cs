using Email;
using FileWork;
using MailGenerator;
using Microsoft.Win32;
using Randomizer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MailGen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<EmailInfo> items { get; set; } = new ObservableCollection<EmailInfo>();
        Reader reader;
        Writer writer;
        Adder adder;
        Generator generator;
        public MainWindow()
        {
            reader = new Reader();
            adder = new Adder();
            writer = new Writer();
            generator = new Generator();
            InitializeComponent();
            datalist.ItemsSource = items;
            datalist.Items.Refresh();
        }

        private async void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            var list = (IList<string>)(await reader.GetListFroFile());

            adder.AddFirstName(list, items);
            datalist.Items.Refresh();
        }

        private async void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var list = (IList<string>)(await reader.GetListFroFile());
            adder.AddSecondName(list, items);
            datalist.Items.Refresh();
        }


        private void Button_Click_shufflefirstname(object sender, RoutedEventArgs e)
        {
            var listfn = items.Select(s => s.Firstname).ToList();
            var listsn = items.Select(s => s.SecondName).ToList();

            MixStringList.GetMix(listfn);
            MixStringList.GetMix(listsn);

            for (int i = 0; i < items.Count; i++)
            {
                items[i].Firstname = listfn[i];
                items[i].SecondName = listsn[i];
            }

        
        datalist.Items.Refresh();
        }

        private void Button_Click_shufflesecondname(object sender, RoutedEventArgs e)
        {
            var list = items.Select(s => s.SecondName).ToList();
            MixStringList.GetMix(list);
            for (int i = 0; i < items.Count; i++)
            {
                items[i].SecondName = list[i];
            }
            datalist.Items.Refresh();
        }

        private  void Button_Click_GENERATION(object sender, RoutedEventArgs e)
        {
            foreach(EmailInfo t in items)
            {
                generator.CreateRandomMail(t);
            }
            datalist.Items.Refresh();
        }

        private async void SaveToFile(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            if (sfd.ShowDialog() == true)
            {
                await writer.WriteListToFile(items.Select(s => s.Firstname).ToList(), sfd.FileName + "FirstNamesFile.txt");
                await writer.WriteListToFile(items.Select(s => s.SecondName).ToList(), sfd.FileName + "SecondName.txt");
                await writer.WriteListToFile(items.Select(s => s.Email).ToList(), sfd.FileName + "Emails.txt");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text.Equals("piska") && password.Password.Equals("pipiska"))
            {
                logingrid.Visibility = Visibility.Hidden;
                maingrid.Visibility = Visibility.Visible;
            }
            else
            {
                badlogin.Text = "неа";
            }
        }

        private void logingrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, e);
            }
        }
    }
}
