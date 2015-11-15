using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaMoarDujmani
{
	public class Repository
	{
		private List<Book> books;

		public Repository()
		{
			books = new List<Book>();
		}

		public void Add(Book book)
		{
			this.books.Add(book);
		}

		public void Remove(Guid id)
		{
			var bookToRemove = this.books.First(b => b.Id == id);
			this.books.Remove(bookToRemove);
		}

		public List<Book> FindByAuthor(string author)
		{
			return books.Where(b => b.Author.Contains(author)).ToList();
		}

		public List<Book> Read()
		{
			return books;
		}
	}
}
