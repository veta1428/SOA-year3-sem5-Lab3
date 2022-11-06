using Library.Types;

namespace Library.EF.Entities
{
    public class Book : Entity<int>
    {
        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public Genre Genre { get; set; }

        public int Pages { get; set; }

        public string FilePath { get; set; } = null!;

        public Library Library { get; set; } = null!;
    }
}
