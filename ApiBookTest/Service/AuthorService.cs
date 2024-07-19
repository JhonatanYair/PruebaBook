using ApiBookTest.Common;
using ApiBookTest.Repositories;
using System.Linq.Expressions;
using ApiBookTest.Models;

namespace ApiBookTest.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<authors> _repository;

        public AuthorService(IRepository<authors> repository)
        {
            _repository = repository;
        }

        public async Task<ResponseApi> GetAuthors(int? id = 0)
        {
            ResponseApi responseApi = new ResponseApi{ Object = new List<authors>(),CodeHttp = System.Net.HttpStatusCode.OK };
            Expression<Func<authors, bool>> query = null;

            if (id != 0)
            {
                query = p => p.id == id;
            }

            Expression<Func<authors, object>> includeBook = p => p.books;
            List<authors> listAuthors = await _repository.ListRecords(query, includeBook);
            responseApi.Object = listAuthors;
            responseApi.Response = $"Se encontraron {listAuthors.Count} registros";
            return responseApi;
        }

        public async Task<ResponseApi> CreateAuthor(authors author)
        {
            authors authors = await _repository.CreateRecord(author);
            ResponseApi responseApi = new ResponseApi 
            { 
                CodeHttp = System.Net.HttpStatusCode.OK,
                Object = authors,
                Response = "Se creo correctamente el autor"
            };

            return responseApi;
        }

        public async Task<ResponseApi> UpdateAuthor(int id, authors author)
        {
            ResponseApi responseApi = new ResponseApi();
            authors productoEdit = new authors();
            Expression<Func<authors, bool>> query = p => p.id == id;

            var authorsFind = await _repository.ListRecords(query);
            var authorPut = authorsFind[0];
            responseApi.Response = "Error no se encontró el autor.";

            if (authorsFind.Count > 0)
            {
                responseApi.Response = "El autor fue editado correctamente.";
                authorPut.id = id;
                authorPut.name = author.name;

                authorPut = await _repository.UpdateRecord(authorPut);
                responseApi.Object = authorPut;
            }
            return responseApi;
        }

        public async Task<ResponseApi> RemoveAuthor(int id)
        {
            ResponseApi responseApi = new ResponseApi();
            Expression<Func<authors, bool>> query = p => p.id == id;
            bool eliminadoAuthor = false;

            var authorFind = await _repository.ListRecords(query);
            responseApi.Response = "Error no se encontró el autor.";

            if (authorFind.Count > 0)
            {
                eliminadoAuthor = await _repository.DeleteRecord(id);
                responseApi.Response = "El autor fue eliminado.";
            }
            return responseApi;
        }
    }

    public interface IAuthorService
    {
        Task<ResponseApi> GetAuthors(int? id = 0);
        Task<ResponseApi> CreateAuthor(authors author);
        Task<ResponseApi> UpdateAuthor(int id, authors author);
        Task<ResponseApi> RemoveAuthor(int id);
    }
}
