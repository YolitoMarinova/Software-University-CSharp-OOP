using System.Collections.Generic;
using System.Linq;
using P02._Books_Before.Contracts;

namespace P02._Books_Before
{
    public class Library : ILibrary
    {
        public Library()
        {
            this.books = new List<Book>();
        }

        public string Name {get;set;}

        public IReadOnlyCollection<IBook> books { get; set; }

        public int BookLocation()
        {
            return 52;
        }
    }
}
