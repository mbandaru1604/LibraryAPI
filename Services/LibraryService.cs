using LibraryAPI.Models;

namespace LibraryAPI.Services
{
    public class LibraryService : ILibraryService
    {
        public List<Libraries> LibraryData()
        {
            List<Libraries> libraries = new();

            libraries.Add(new Libraries
            {
                Id = 1,
                Name = "Oxford Library"
            });
            libraries.Add(new Libraries
            {
                Id = 2,
                Name = "Himalayan Library",
            });
            return libraries;
        }

        public CustomResponse DeleteLibrary(int libraryId)
        {
            CustomResponse response = new CustomResponse();
            var library= LibraryData().Where(l => l.Id == libraryId).FirstOrDefault();
            if (library == null)
            {
                response.Result = null;
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                response.ErrorMessage = "Library Not found";
                return response;
            }

            LibraryData().Remove(library);
            response.Result = null;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            response.ErrorMessage = "";
            response.IsSuccess = true;
            return response;
        }
    }
}
