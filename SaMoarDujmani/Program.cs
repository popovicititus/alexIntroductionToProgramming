using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaMoarDujmani
{
	class Program
	{
		private static Repository bookRepository;

		private static int? ReadNumber()
		{
			var input = Console.ReadLine();
			int result;
			var isNumber = int.TryParse(input, out result);
			if(isNumber){
				return result;
			}
			else{
				return null;
			}
		}

		static void Main(string[] args)
		{
			bookRepository = new Repository();
			while (true)
			{
				ShowMenu();
				Console.WriteLine("Introdu operatie:");
				var operation = ReadNumber();
				switch (operation)
				{
					case null: ShowInputError();
							break;
					case 0: ShowBooks();
							break;
					case 1: AddBook();
							break;
					case 2: RemoveBook();
							break;
					case 3: FilterByAuthor();
							break;
					case 9: Environment.Exit(0);
							break;
					default: break;
				}
			}
		}

		public static void ShowInputError()
		{
			Console.Clear();
			Console.WriteLine("Wrong input, mothafucka!");
		}

		public static void FilterByAuthor()
		{
			Console.WriteLine("Name of the author:");
			var author = Console.ReadLine();
			var books = bookRepository.FindByAuthor(author);
			foreach (var b in books)
			{
				Console.WriteLine(b);
			}
		}

		public static void ShowMenu()
		{
			Console.WriteLine("0:Show all books\n1:Add book\n2:Remove book\n3:Filter by author\n9:Exit");
		}

		public static void ShowBooks()
		{
			Console.Clear();
			var books = bookRepository.Read();
			for(var i=0; i < books.Count; i++)
			{
				Console.WriteLine(i + ". " + books[i]);
			}
		}

		public static void AddBook()
		{
			Console.WriteLine("Introdu numele:");
			var name = Console.ReadLine();
			Console.WriteLine("Introdu autorul:");
			var author = Console.ReadLine();
			var book = new Book(name, author);
			bookRepository.Add(book);
			Console.Clear();
		}

		public static void RemoveBook()
		{
			ShowBooks();
			Console.WriteLine("Enter the index of the book you wanna fuck up:");
			var index = Convert.ToInt32(Console.ReadLine());
			var books = bookRepository.Read();
			var bookId = books.ElementAt(index).Id;
			bookRepository.Remove(bookId);
			Console.Clear();
		}
	}
}
