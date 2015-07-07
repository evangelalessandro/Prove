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

namespace AutoScrollListBox
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Inno> m_selectedEquipmentHorizontal = new ObservableCollection<Inno>();
        ObservableCollection<Inno> m_selectedEquipmentVertical = new ObservableCollection<Inno>();


        public MainWindow()
        {
            InitializeComponent();
        }


        protected override void OnInitialized( EventArgs e )
        {
            base.OnInitialized( e );

             
            ObservableCollection<Inno> equipmentList2 = new ObservableCollection<Inno>();
            this.verticalListBox.ItemsSource = equipmentList2;
            CreateEquipments( equipmentList2, "Tank-" );
            //this.verticalSelectedItemsListBox.ItemsSource = m_selectedEquipmentVertical;
        }


        private ObservableCollection<Inno> CreateEquipments( ObservableCollection<Inno> equipmentList, string prefix )
        {
            int maxItemCount = 500;
            for( int i = 0; i < maxItemCount; i++ )
            {
                equipmentList.Add( new Inno() { Nome = prefix + i.ToString(), Numero =  i } );
            }
            return equipmentList;
        }



        private void horizontalListBox_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            if( e.AddedItems.Count > 0 )
            {
                foreach( Inno item in e.AddedItems )
                {
                    m_selectedEquipmentHorizontal.Add( item );
                }
            }

            if( e.RemovedItems.Count > 0 )
            {
                foreach( Inno item in e.RemovedItems )
                {
                    m_selectedEquipmentHorizontal.Remove( item );
                }
            }
        }

        private void verticalListBox_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            if( e.AddedItems.Count > 0 )
            {
                foreach( Inno item in e.AddedItems )
                {
                    m_selectedEquipmentVertical.Add( item );
                }
            }

            if( e.RemovedItems.Count > 0 )
            {
                foreach( Inno item in e.RemovedItems )
                {
                    m_selectedEquipmentVertical.Remove( item );
                }
            }
        }

    }
}
