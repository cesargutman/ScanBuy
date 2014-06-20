using System;
using SQLite;

namespace ScanBuy
{
	public class Product
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Barcode { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public DateTime Date { get; set; }
	}
}

