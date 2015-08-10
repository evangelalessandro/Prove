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
    public partial class 
        MainWindow : Window
    {
        private ObservableCollection<Inno> _himnListSelect = new ObservableCollection<Inno>();
        private System.Timers.Timer _tm = new System.Timers.Timer(3000);
        private ObservableCollection<Inno> _himsList = new ObservableCollection<Inno>();


        public MainWindow()
        {
            
            InitializeComponent();
        }


        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            ReadHimns();
            _tm.Enabled = true;
            _tm.Elapsed += _tm_Elapsed;
            _tm.Start();
            this.verticalListBox.ItemsSource = _himsList;
        }

        private void _tm_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            
            _tm.Stop();
            _tm.Dispose();


            ReadHimns();
        }

        private void ReadHimns()
        {
            if (!CheckAccess())
            {
                // On a different thread
                Dispatcher.Invoke(() => ReadHimns());
                return;
            }

            var dirPPT = Properties.Settings.Default.DirPPT;
            var himsFilePpt = Directory.GetFiles(dirPPT, "*.ppt");

            foreach (var item in himsFilePpt)
            {
                var file = new FileInfo(item);
                var numero = getNumero(file);
                var nomeFile = GetNameHims(file);
                _himsList.Add(new Inno() { Nome = nomeFile, Numero = numero, PPT = file });
            }

            var dirMp3 = Innario.Properties.Settings.Default.DirMp3;
            var himsFileMp3 = Directory.GetFiles(dirMp3, "*.mp3").Select(a => new FileInfo(a)).ToList();

            foreach (var item in himsFileMp3)
            {
                var numero = getNumero(item);
                var find = _himsList.Where(a => a.Numero == numero).ToList();
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

            _himsList = new ObservableCollection<Inno>(_himsList.OrderBy(a => a.Numero).ToList());

            verticalListBox.SelectedIndex = 0;
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
            //if (e.AddedItems.Count > 0)
            //{
            //    foreach (Inno item in e.AddedItems)
            //    {
            //        _himnList.Add(item);
            //    }
            //}

            //if (e.RemovedItems.Count > 0)
            //{
            //    foreach (Inno item in e.RemovedItems)
            //    {
            //        _himnList.Remove(item);
            //    }
            //}
            //btnAvviaPresentazione.IsEnabled = _himnList.Count() > 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartPresentation();
        }

        private void StartPresentation()
        {
            if (verticalListBox.SelectedItem != null)
            {
                var innoitem = (Inno)verticalListBox.SelectedItem;

                if (innoitem.MP3 != null)
                {
                    Process.Start(innoitem.MP3.FullName);
                }

                Process.Start(Innario.Properties.Settings.Default.PPTExePAth, "/S " + @"""" + innoitem.PPT.FullName + @"""");
            }
        }

        private void verticalListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                StartPresentation();
            }

        }

        private void verticalListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            StartPresentation();
        }
    }
}
