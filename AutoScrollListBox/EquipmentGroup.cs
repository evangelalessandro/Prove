using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoScrollListBox
{
    public class EquipmentGroup
    {
        public string Name { get; set; }

        public Dictionary<string, List<EquipmentItem>> EquipmentGroupByCategory = new Dictionary<string, List<EquipmentItem>>();

        public EquipmentGroup()
        {
            EquipmentGroupByCategory.Add("Tanks", new List<EquipmentItem>());
            EquipmentGroupByCategory.Add("Reactors", new List<EquipmentItem>());
            EquipmentGroupByCategory.Add("Filters", new List<EquipmentItem>());
            EquipmentGroupByCategory.Add("Dryers", new List<EquipmentItem>());
            EquipmentGroupByCategory.Add("Milles", new List<EquipmentItem>());
        }

    }
}
