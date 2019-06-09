﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HCI_zadatak_2
{
	class HelpProvider
	{
		public static string GetHelpKey(DependencyObject obj)
		{
			return obj.GetValue(HelpKeyProperty) as string;
		}

		public static void SetHelpKey(DependencyObject obj, string value)
		{
			obj.SetValue(HelpKeyProperty, value);
		}

		public static readonly DependencyProperty HelpKeyProperty =
			DependencyProperty.RegisterAttached("HelpKey", typeof(string), typeof(HelpProvider), new PropertyMetadata("index", HelpKey));
		private static void HelpKey(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			//NOOP
		}

		public static void ShowHelp(string key)
		{
			HelpView hh = new HelpView(key);
			hh.Show();
		}
	}
}
