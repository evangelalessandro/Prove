using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.IO;

namespace Innario
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Inno> _himnList = new ObservableCollection<Inno>();


        public MainWindow()
        {
            InitializeComponent();
        }


        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            ReadHimns();
        }


        private void ReadHimns()
        {
            var himsList = new ObservableCollection<Inno>();
            var dir=@"C:\Users\ale\Downloads\PowerPointCanti";
            var himsFile = Directory.GetFiles(dir, "*.ppt");

            foreach (var item in himsFile)
            {
                var file = new FileInfo(item);
                var numero = int.Parse(file.Name.Substring(0, 3));

                himsList.Add(new Inno() { Nome = file.Name, Numero = numero,PPT=file });
            }
            this.verticalListBox.ItemsSource = himsList;
        }





        private void verticalListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                foreach (Inno item in e.AddedItems)
                {
                    _himnList.Add(item);
                }
            }

            if (e.RemovedItems.Count > 0)
            {
                foreach (Inno item in e.RemovedItems)
                {
                    _himnList.Remove(item);
                }
            }
            btnAvviaPresentazione.IsEnabled = _himnList.Count() > 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
