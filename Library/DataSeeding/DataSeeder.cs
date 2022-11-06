using Library.EF;
using Library.EF.Entities;
using CoreLibrary = Library.EF.Entities.Library;


namespace Library.DataSeeding
{
    public class DataSeeder
    {
        private readonly LibraryContext _libraryContext;

        public DataSeeder(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task SeedData(CancellationToken cancellationToken)
        {
            var library1 = new CoreLibrary() { Name = "Библиотека №4 имени Н. В. Гоголя", Address = "улица Лобанка 22, Минск", Email = "gogol4@gmail.com", Description = "Большой выбор не только книг доя взрослых, но школьной литературы.", Phone = "8 017 353-13-95" };

            var book1 = new Book() { Title = "Введение в математическую экологию", Author = "Л. А. Петросян, В. В. Захаров", FilePath = "mat_ecology.pdf", Genre = Types.Genre.Science, Pages = 224};
            var book2 = new Book() { Title = "Теория вероятностей", Author = "Е. Г. Красногир", FilePath = "krasnogir_twims.pdf", Genre = Types.Genre.Science, Pages = 46 };
            var book3 = new Book() { Title = "Безопасность жизнедеятельности", Author = "Занько Н. Г., Малаян К. Р., Русак О. Н", FilePath = "bezop_zyzn_chel.pdf", Genre = Types.Genre.Science, Pages = 704 };

            library1.Books.Add(book1);
            library1.Books.Add(book2);
            library1.Books.Add(book3);

            var library2 = new CoreLibrary() { Name = "Минская областная библиотека им. А.С. Пушкина", Address = "ул. Гикало 4, Минск 220005", Email = "puszkin@gmail.com", Description = "Публичная библиотека в Минске", Phone = "8 017 350-06-14" };

            var book4 = new Book() { Title = "Введение в машинное обучение с помощью Python", Author = "Андреас Мюлерб Сара Гвидо", FilePath = "ml_python.pdf", Genre = Types.Genre.Science, Pages = 393 };
            var book5 = new Book() { Title = "Практикум по дифференциальным уравнениям", Author = "Л. А. Альсевич, Л. П. Черенкова", FilePath = "practicum_du.pdf", Genre = Types.Genre.Science, Pages = 160 };
            var book6 = new Book() { Title = "Pyhton на примерах", Author = "Васильев А. Н.", FilePath = "python_examples.pdf", Genre = Types.Genre.Science, Pages = 430 };

            library2.Books.Add(book4);
            library2.Books.Add(book5);
            library2.Books.Add(book6);

            var library3 = new CoreLibrary() { Name = "Библиотека № 12", Address = " ул. Авроровская 8, Минск", Email = "lib12@gmail.com", Description = "Библиотека в Минске", Phone = "8 017 370-04-71" };

            var book7 = new Book() { Title = "Основы радиационной безопасности", Author = "В. А. Саечников, В. М. Зеленкевич", FilePath = "radioc_bezop.pdf", Genre = Types.Genre.Science, Pages = 94 };
            var book8 = new Book() { Title = "Архитектура компьютера", Author = "Э. Таненбаумб, Т. Остин", FilePath = "tanenbaum.pdf", Genre = Types.Genre.Science, Pages = 816 };
            var book9 = new Book() { Title = "Справочник по вероятностным распределениям", Author = "Р. Н. Вадзинский", FilePath = "vadzinski.pdf", Genre = Types.Genre.Science, Pages = 149 };

            library3.Books.Add(book7);
            library3.Books.Add(book8);
            library3.Books.Add(book9);

            _libraryContext.Libraries.Add(library1);
            _libraryContext.Libraries.Add(library2);
            _libraryContext.Libraries.Add(library3);

            await _libraryContext.SaveChangesAsync(cancellationToken);
        }
    }
}
