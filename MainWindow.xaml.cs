﻿using System;
using System.Collections.Generic;
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

namespace MarkCurran_S00199895
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		GameData db = new GameData();
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			

			var query = from g in db.Games
						select g;
			lbx_games.ItemsSource = query.ToList();

			string[] filters =
			{
				"PC, Xbox, PS, Switch",
				"Xbox",
				"PS",
				"Switch"
			};

			filterBox.ItemsSource = filters;
		}

		private void lbx_games_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Game selectedGame = lbx_games.SelectedItem as Game;

			if (selectedGame != null)
			{
				tblk_gamePrice.Text = $"{selectedGame.Price:C}";
				tblk_name.Text = selectedGame.Name;
				tblk_desc.Text = selectedGame.Description;
			}
		}

		private void filterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string selectedOption = filterBox.SelectedItem as string;

			if (selectedOption != null)
			{
				var query = from g in db.Games
							where g.Platform == selectedOption
							select g;

				lbx_games.ItemsSource = query.ToList();
			}
		}
	}
}
