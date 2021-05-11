using System;
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
		//Initalizing db for the xaml.cs
		GameData db = new GameData();
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			//select all games
			var query = from g in db.Games
						select g;
			lbx_games.ItemsSource = query.ToList();
		}

		private void lbx_games_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Game selectedGame = lbx_games.SelectedItem as Game;

			if (selectedGame != null)
			{
				//Set the text blocks to the selected game's info
				tblk_plat.Text = $"Platform: {selectedGame.Platform}";
				tblk_price.Text = $"Price: {selectedGame.Price:C}";
				tblk_desc.Text = $"Description: \\n{selectedGame.Description}";
			}
		}

		private void RadioButton_Click(object sender, RoutedEventArgs e)
		{

			if (btnAll.IsChecked == true)
			{
				 var query = from g in db.Games
						select g;
				lbx_games.ItemsSource = query.ToList();
			}
			else if (btnXbox.IsChecked == true)
			{
				var query = from g in db.Games
							where g.Platform == "Xbox"
							select g;
				lbx_games.ItemsSource = query.ToList();
			}
			else if (btnPS.IsChecked == true)
			{
				var query = from g in db.Games
							where g.Platform == "PS"
							select g;
				lbx_games.ItemsSource = query.ToList();
			}
			else if (btnSwitch.IsChecked == true)
			{
				var query = from g in db.Games
							where g.Platform == "Switch"
							select g;
				lbx_games.ItemsSource = query.ToList();
			}
		}
	}
}
