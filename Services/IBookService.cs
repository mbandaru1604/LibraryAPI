using LibraryAPI.Models;

namespace LibraryAPI.Services
{
    public interface IBooksService
    {
        CustomResponse GetBooks(int libraryId);
        CustomResponse AddBook(int libraryId, Books book);
    }
}
