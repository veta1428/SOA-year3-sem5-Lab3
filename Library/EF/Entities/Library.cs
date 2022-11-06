namespace Library.EF.Entities
{
    public class Library : Entity<int>
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();


    }
}
