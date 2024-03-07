using LibraryAPI.Models;

namespace LibraryAPI.Services
{
    public class Bookservice : IBooksService
    {

        ILibraryService _libraryService;
        public Bookservice(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }
        public CustomResponse AddBook(int libraryId,Books book)
        {
            List<Books> books = new();

            var libraries =  _libraryService.LibraryData();
            CustomResponse response = new CustomResponse();
            var library = libraries.Where(l => l.Id == libraryId).FirstOrDefault();
            if (library == null)
            {
                response.Result = null;
                response.StatusCode =System.Net.HttpStatusCode.NotFound;
                response.ErrorMessage = "Library Not found";
                return response;
            }

            books.Add(book);
            response.Result = true;
            response.StatusCode = System.Net.HttpStatusCode.Created;
            response.ErrorMessage = "";
            response.IsSuccess = true;
            return response;
        }
        public CustomResponse GetBooks(int libraryId)
        {
            var books = BookData().Where(l => l.LibraryId == libraryId).ToList();
            CustomResponse response = new();
            if (books == null)
            {
                response.Result = null;
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                response.ErrorMessage = "Book data not found";
                response.IsSuccess = false;
                return response;
            }
            
            response.Result = books;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            response.ErrorMessage = "";
            response.IsSuccess = true;
            return response;
        }

        private List<Books> BookData()
        {
            List<Books> books = new();// List<Books>();
            books.Add(new Books
            {
                Id = 1,
                Name = "Life of Sachin",
                Category = "Biopic",
                LibraryId = 1
            });
            books.Add(new Books
            {
                Id = 2,
                Name = "Festival of food",
                Category = "Food",
                LibraryId = 1
            });
            books.Add(new Books
            {
                Id = 3,
                Name = "Market Strategy",
                Category = "Financial Banking",
                LibraryId = 1
            });
            books.Add(new Books
            {
                Id = 5,
                Name = "Great Politicians",
                Category = "Politics",
                LibraryId = 2
            });
            return books;
            /*
            for (int i = 1; i < 10; i++)
            {
                yield return new Books
                {
                    Id = i,
                    Name = $"Book{i}",
                    Category = "Knowledge",
                    LibraryId = 1
                };
            }
            */
        }

    }
}
