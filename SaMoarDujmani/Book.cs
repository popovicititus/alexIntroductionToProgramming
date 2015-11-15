using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaMoarDujmani
{
	public class Book
	{
		public string Name { get; set;}
		public string Author { get; set;}
		public Guid Id {get; set;}

		public Book()
		{

		}

		public Book(string name, string author)
		{
			if (String.IsNullOrWhiteSpace(name))
			{
				throw new Exception("Tuti gura matii ca n-are nume");
			}
			if(String.IsNullOrWhiteSpace(author))
			{
				throw new Exception("Tuti ceapa matii ca n-are autor");
			}

			this.Name = name;
			this.Author = author;
			this.Id = new Guid();
		}

		public override string ToString()
		{
			return this.Name + " - " + this.Author;
		}
	}
}
