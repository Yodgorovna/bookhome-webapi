using Bookhome.Application.Utils;
using Bookhome.DataAcces.Interfaces.Books;
using BookHome.Domain.Entities.Authors;
using BookHome.Domain.Entities.Books;
using Dapper;

namespace Bookhome.DataAcces.Repositories.Books
{
    public class BookImageRepository :BaseRepository, IBookImageRepository
    {
        public async Task<long> CountAsync()
        {
            try
            {
                await _connection.OpenAsync();
                string query = "select count(*) from book_images";
                var result = await _connection.QuerySingleAsync<long>(query);

                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<int> CreateAsync(BookImage entity)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "Insert into book_images(book_id, image_path, created_at, updated_at) " +
                    "values(@BookId, @ImagePath, @CreatedAt, @UpdatedAt) RETURNING id ";

                var result = await _connection.ExecuteScalarAsync<int>(query, entity);

                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<int> DeleteAsync(long id)
        {
            try
            {
                await _connection.OpenAsync();
                string query = "Delete from book_images where book_id = @ID or id = @ID";
                var result = await _connection.ExecuteAsync(query, new { ID = id });

                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<IList<BookImage>> GetAllAsync(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();

                string qauery = "SELECT * FROM book_images order by id desc " +
                                    $"offset {@params.GetSkipCount()} limit {@params.PageSize} ";

                var result = (await _connection.QueryAsync<BookImage>(qauery)).ToList();

                return result;
            }
            catch
            {
                return new List<BookImage>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public Task<List<BookImage>> GetByIdAllAsync(long Id)
        {
            throw new NotImplementedException();
        }

        public async Task<BookImage?> GetByIdAsync(long id)
        {
            try
            {
                await _connection.OpenAsync();

                string query = "select * from book_images  where book_id = @ID";
                var result = (await _connection.QuerySingleAsync<BookImage>(query, new { ID = id }));

                return result;
            }
            catch
            {
                return null;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<List<BookImage>> GetFirstAllAsync()
        {
            try
            {
                await _connection.OpenAsync();

                string query = "SELECT id, book_id, image_path, created_at, updated_at " +
                    "FROM public.book_images WHERE (book_id, id) " +
                        "IN (SELECT book_id, MIN(id) FROM public.book_images " +
                            "GROUP BY book_id ) ORDER BY id DESC";

                var result = (await _connection.QueryAsync<BookImage>(query)).ToList();

                return result;
            }
            catch
            {
                return new List<BookImage>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<int> UpdateAsync(long id, BookImage entity)
        {
            try
            {
                await _connection.OpenAsync();

                string query = $"UPDATE book_images " +
                    $"SET book_id=@BookId, image_path=@ImagePath, created_at=@CreatedAt, " +
                        $" updated_at=@UpdatedAt WHERE id={id};";

                var result = await _connection.ExecuteAsync(query, entity);

                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }
    }
}
