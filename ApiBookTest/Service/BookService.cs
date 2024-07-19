using ApiBookTest.Common;
using ApiBookTest.Models;
using ApiBookTest.Repositories;
using System.Linq.Expressions;

namespace ApiBookTest.Service
{

    public class BookService : IBookService
    {
        private readonly IRepository<books> _repository;

        public BookService(IRepository<books> repository)
        {
            _repository = repository;
        }

        public async Task<ResponseApi> GetBooks(int? id = 0)
        {
            ResponseApi responseApi = new ResponseApi { Object = new List<books>(), CodeHttp = System.Net.HttpStatusCode.OK };
            Expression<Func<books, bool>> query = null;

            if (id != 0)
            {
                query = p => p.id == id;
            }

            Expression<Func<books, object>> includeBook = p => p.author;
            List<books> listBooks = await _repository.ListRecords(query, includeBook);
            responseApi.Object = listBooks;
            responseApi.Response = $"Se encontraron {listBooks.Count} registros";
            return responseApi;
        }

        public async Task<ResponseApi> CreateBook(books book)
        {
            books bookCreate = await _repository.CreateRecord(book);
            ResponseApi responseApi = new ResponseApi
            {
                CodeHttp = System.Net.HttpStatusCode.OK,
                Object = bookCreate,
                Response = "Se creo correctamente el libro"
            };

            return responseApi;
        }

        public async Task<ResponseApi> UpdateBook(int id, books book)
        {
            ResponseApi responseApi = new ResponseApi();
            books bookEdit = new books();
            Expression<Func<books, bool>> query = p => p.id == id;

            var bookFind = await _repository.ListRecords(query);
            var bookPut = bookFind[0];
            responseApi.Response = "Error no se encontró el libro.";

            if (bookFind.Count > 0)
            {
                responseApi.Response = "El libro fue editado correctamente.";
                bookPut.id = id;
                bookPut.title = book.title;
                bookPut.author_id = book.author_id;
                bookPut = await _repository.UpdateRecord(bookPut);
                responseApi.Object = bookPut;
            }
            return responseApi;
        }

        public async Task<ResponseApi> RemoveBook(int id)
        {
            ResponseApi responseApi = new ResponseApi();
            Expression<Func<books, bool>> query = p => p.id == id;
            bool eliminadoBook = false;

            var bookFind = await _repository.ListRecords(query);
            responseApi.Response = "Error no se encontró el libro.";

            if (bookFind.Count > 0)
            {
                eliminadoBook = await _repository.DeleteRecord(id);
                responseApi.Response = "El libro fue eliminado.";
            }
            return responseApi;
        }
    }

    public interface IBookService
    {
        Task<ResponseApi> GetBooks(int? id = 0);
        Task<ResponseApi> CreateBook(books book);
        Task<ResponseApi> UpdateBook(int id, books book);
        Task<ResponseApi> RemoveBook(int id);
    }


}
