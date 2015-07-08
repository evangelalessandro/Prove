﻿using System;
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
using System.Collections;
using System.Windows.Controls.Primitives;

namespace WpfControls
{
	/// <summary>
	/// Interaction logic for ListBoxWithAutoScroll.xaml
	/// </summary>
	public partial class ListBoxWithAutoScroll : UserControl
	{


		public ListBoxWithAutoScroll()
		{
			InitializeComponent();
		}


		public IEnumerable ItemsSource
		{
			get { return listBox.ItemsSource; }
			set { listBox.ItemsSource = value; }
		}

		public DataTemplate ItemTemplate
		{
			get { return listBox.ItemTemplate; }
			set { listBox.ItemTemplate = value; }
		}

		
		
	}
}
