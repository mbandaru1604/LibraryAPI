using LibraryAPI.Models;

namespace LibraryAPI.Services
{
    public interface ILibraryService
    {
        CustomResponse DeleteLibrary(int libraryId);
        List<Libraries> LibraryData();
    }
}
