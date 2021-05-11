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
		[Key]
		public string Name { get; set; }
		public int CriticScore { get; set; }
		public string Description { get; set; }
		public string Platform { get; set; }
		public decimal Price { get; set; }
		public string GameImage { get; set; }

		public Game()
		{

		}

		public void DecreasePrice(decimal amount)
		{
			Price -= amount;
		}
	}

	public class GameData : DbContext
	{
		public GameData() : base("GameInfo") { }
		public DbSet<Game> Games { get; set; }
	}
}
