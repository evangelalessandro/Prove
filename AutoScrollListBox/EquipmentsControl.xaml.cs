using System;
using System.Collections;
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

namespace AutoScrollListBox
{
    /// <summary>
    /// Interaction logic for EquipmentsControl.xaml
    /// </summary>
    public partial class EquipmentsControl : UserControl
    {
        private Random random = new Random();

        private Style equipmentListBoxStyle;
        private Style groupContainerStyle;
        private Style expanderStyle;      

        private DataTemplate equipmentItemTemplate;
        private ControlTemplate headerLabelTemplate;

        List<EquipmentGroup> equipmentGroups = new List<EquipmentGroup>();

        public EquipmentsControl()
        {
            InitializeComponent();

            equipmentItemTemplate = (DataTemplate)this.FindResource("EquipmentItemTemplate");
            equipmentListBoxStyle = (Style)this.FindResource("EquipmentListBoxStyle");
            groupContainerStyle = (Style)this.FindResource("GroupContainerStyle");
            expanderStyle = (Style)this.FindResource("ExpanderStyle");

            headerLabelTemplate = (ControlTemplate)this.FindResource("HeaderLabelTemplate");

            CreateEquipmentGroups();
            BindEquipmentGroups();
        }

        private UIElement CreateEquipmentHeaderAndList(IEnumerable itemsSource, string headerLabel, int index)
        {
			Grid grid = new Grid();
			ColumnDefinition colDef = new ColumnDefinition();
            colDef.Width = new GridLength(58);
            grid.ColumnDefinitions.Add(colDef);
            grid.ColumnDefinitions.Add(new ColumnDefinition());

			Button header = new Button() { Content = headerLabel };
            header.Template = headerLabelTemplate;         
        
            header.HorizontalAlignment = HorizontalAlignment.Left;

            header.SetValue(Grid.ColumnProperty, 0);
            grid.Children.Add(header);


			DraggableListView list = new DraggableListView() { SelectionMode = SelectionMode.Single };
            list.Name = "DraggableListView" + headerLabel + index;
            list.VerticalAlignment = VerticalAlignment.Stretch;
            list.HorizontalAlignment = HorizontalAlignment.Stretch;
            list.Style = equipmentListBoxStyle;
            list.ItemTemplate = equipmentItemTemplate;
            list.ItemsSource = itemsSource;
            
            list.SetValue(Grid.ColumnProperty, 1);
            grid.Children.Add(list);

            return grid;
        }

        private void BindEquipmentGroups()
        {
            foreach (EquipmentGroup equipmentGroup in equipmentGroups)
            {
                var groupContainer = new Border();
                groupContainer.Style = groupContainerStyle;

                var expander = new Expander();
                expander.Style = expanderStyle;
                groupContainer.Child = expander;

                var group = new StackPanel() { Orientation = Orientation.Vertical };
                //group.Visibility = Visibility.Collapsed;

                expander.Content = group;
                expander.Header = equipmentGroup.Name;

                int index = EquipmentGroupList.Children.Count;

                if (index == 0)
                    expander.IsExpanded = true;

                UIElement tanksCtrl = CreateEquipmentHeaderAndList(equipmentGroup.EquipmentGroupByCategory["Tanks"], "Tanks", index);
                group.Children.Add(tanksCtrl);

                UIElement reactorsCtrl = CreateEquipmentHeaderAndList(equipmentGroup.EquipmentGroupByCategory["Reactors"], "Reactors", index);
                group.Children.Add(reactorsCtrl);

                UIElement filtersCtrl = CreateEquipmentHeaderAndList(equipmentGroup.EquipmentGroupByCategory["Filters"], "Filters", index);
                group.Children.Add(filtersCtrl);

                UIElement dryersCtrl = CreateEquipmentHeaderAndList(equipmentGroup.EquipmentGroupByCategory["Dryers"], "Dryers", index);
                group.Children.Add(dryersCtrl);

                UIElement millesCtrl = CreateEquipmentHeaderAndList(equipmentGroup.EquipmentGroupByCategory["Milles"], "Milles", index);
                group.Children.Add(millesCtrl);

                EquipmentGroupList.Children.Add(groupContainer);
            }
        }

        private void CreateEquipmentGroups()
        {
            int maxItemCount = 10;
            for (int i = 0; i < maxItemCount; i++)
            {
				EquipmentGroup equipmentGroup = new EquipmentGroup();
                equipmentGroup.Name = "Plant-" + i.ToString();

                List<EquipmentItem> tanks = equipmentGroup.EquipmentGroupByCategory["Tanks"];
                CreateEquipments(tanks, "Tank-");

                List<EquipmentItem> reactors = equipmentGroup.EquipmentGroupByCategory["Reactors"];
                CreateEquipments(reactors, "Reactor-");

                List<EquipmentItem> filters = equipmentGroup.EquipmentGroupByCategory["Filters"];
                CreateEquipments(filters, "Filter-");

                List<EquipmentItem> drayers = equipmentGroup.EquipmentGroupByCategory["Dryers"];
                CreateEquipments(drayers, "Dryer-");

                List<EquipmentItem> milles = equipmentGroup.EquipmentGroupByCategory["Milles"];
                CreateEquipments(milles, "Mill-");

                equipmentGroups.Add(equipmentGroup);
            }

        }

        private void CreateEquipments(List<EquipmentItem> equipmentList, string prefex)
        {
            int maxItemCount = 30;
            for (int i = 0; i < maxItemCount; i++)
            {
                equipmentList.Add(new EquipmentItem() { Name = prefex + i.ToString(), CampaignName = "Camp" + i.ToString() });
            }

        }

    }
}
