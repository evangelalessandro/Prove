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
using System.Diagnostics;

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
            var dirPPT = Innario.Properties.Settings.Default.DirPPT;
            var himsFilePpt = Directory.GetFiles(dirPPT, "*.ppt");



            foreach (var item in himsFilePpt)
            {
                var file = new FileInfo(item);
                var numero = getNumero(file);
                var nomeFile = GetNameHims(file);

                himsList.Add(new Inno() { Nome = nomeFile, Numero = numero, PPT = file });
            }

            var dirMp3 = Innario.Properties.Settings.Default.DirMp3;
            var himsFileMp3 = Directory.GetFiles(dirMp3, "*.mp3").Select(a => new FileInfo(a)).ToList();

            foreach (var item in himsFileMp3)
            {
                var numero = getNumero(item);


                var find = himsList.Where(a => a.Numero == numero).ToList();

                if (find.Count == 1)
                {
                    var itemSelect = find.First();
                    itemSelect.MP3 = item;
                    var nameFind = GetNameHims(item);
                    if (nameFind.Length > itemSelect.Nome.Length)
                    {
                        itemSelect.Nome = nameFind;
                    }
                }
            }

            himsList=new ObservableCollection<Inno>( himsList.OrderBy(a=>a.Numero).ToList());
            this.verticalListBox.ItemsSource = himsList;
        }

        private static string GetNameHims(FileInfo file)
        {
            var nomeFile = file.Name.Substring(0, file.Name.Length - 4);
            return nomeFile;
        }

        private static int getNumero(FileInfo file)
        {
            var nomeFileSenzaEstensione = file.Name.Substring(0, 3);

            var numeroFile = new StringBuilder();
            var caratteri = nomeFileSenzaEstensione.Trim().ToArray().ToList();
            foreach (var item in caratteri)
            {
                if (Char.IsNumber(item.ToString(), 0))
                {
                    numeroFile.Append(item);
                }
                else
                {
                    break;
                }
            }
            var numero = int.Parse(numeroFile.ToString());
            return numero;
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
            if (_himnList.First().MP3 != null)
            {
                Process.Start(_himnList.First().MP3.FullName);
            }

            Process.Start(Innario.Properties.Settings.Default.PPTExePAth,"/S " + @"""" +  _himnList.First().PPT.FullName + @"""");

        }

    }
}
