using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkCurran_S00199895
{
	public class Game
	{
		//props
		[Key]
		public string Name { get; set; }
		public int CriticScore { get; set; }
		public string Description { get; set; }
		public string Platform { get; set; }
		public decimal Price { get; set; }
		public string GameImage { get; set; }

		//ctor
		public Game()
		{

		}
		//methods
		public void DecreasePrice(decimal amount)
		{
			//Reduce the price by the amount argument
			Price -= amount;
		}

		public override string ToString()
		{
			return Name;
		}
	}

	//Creates the DB structure with the Entity Framework
	public class GameData : DbContext
	{
		//The name of the database will be GameInfo
		public GameData() : base("GameInfo") { }
		public DbSet<Game> Games { get; set; } //The table will be called Games
	}
}
