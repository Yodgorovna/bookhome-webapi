using Bookhome.Application.Exceptions.Authors;
using Bookhome.Application.Exceptions.Books;
using Bookhome.Application.Exceptions.Categories;
using Bookhome.Application.Exceptions.Files;
using Bookhome.Application.Utils;
using Bookhome.DataAcces.Interfaces.Books;
using Bookhome.DataAcces.Interfaces.Categories;
using Bookhome.DataAcces.ViewModels.Books;
using Bookhome.Services.Helpers;
using Bookhome.Services.Interfaces.Books;
using Bookhome.Services.Interfaces.Common;
using BookHome.Domain.Entities.Authors;
using BookHome.Domain.Entities.Books;
using BookHome.Persistance.Dtos.Books;

namespace Bookhome.Services.Services.Books;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IFileService _fileService;
    private readonly IBookImageRepository _imageRepository;
    private readonly string BOOKIMAGES = "BookImages";
    private readonly IPaginator _paginator;

    public BookService(IBookRepository bookRepository,
        ICategoryRepository categoryRepository,
        IFileService fileService,
        IBookImageRepository bookImageRepository,
        IPaginator paginator)
    {
        this._repository = bookRepository;
        this._categoryRepository = categoryRepository;
        this._fileService = fileService;
        this._imageRepository = bookImageRepository;
        _paginator = paginator;

    }
    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(BookCreateDto dto)
    {
        var check = await _categoryRepository.GetByIdAsync(dto.CategoryId);
        if (check.Id == 0)
        {
            throw new CategoryNotFoundException();
        }

        Book book = new Book()
        {
            CategoryId = dto.CategoryId,
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            IsHardCover = dto.IsHardCover,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime(),
        };

        var DbResult = await _repository.CreateAsync(book);

        if (DbResult > 0)
        {
            foreach (var item in dto.ImagePath)
            {
                var img = await _fileService.UploadImageAsync(item, BOOKIMAGES);

                BookImage bookImage = new BookImage()
                {
                    BookId = DbResult,
                    ImagePath = img,
                    CreatedAt = TimeHelper.GetDateTime(),
                    UpdatedAt = TimeHelper.GetDateTime(),
                };

                var DbImgResult = await _imageRepository.CreateAsync(bookImage);
            }

            return true;
        }

        return false;
    }

    public async Task<bool> DeleteAsync(long bookId)
    {
        var book = await _repository.GetByIdAsync(bookId);
        if (book is null) throw new BookNotFoundException();

        var result = await _repository.DeleteAsync(bookId);
        return result > 0;
        //var DbFound = await _repository.GetByIdAsync(bookId);

        //if (DbFound.Id == 0)
        //    throw new BookNotFoundException();

        //var DbImgAll = await _imageRepository.GetByIdAllAsync(bookId);

        //if (DbImgAll.Count == 0)
        //    throw new ImageNotFoundException();

        //var DbImgResult = await _imageRepository.DeleteAsync(bookId);
        //var DbResult = await _repository.DeleteAsync(bookId);

        //if (DbResult > 0 && 0 < DbImgResult)
        //{
        //    foreach (var item in DbImgAll)
        //    {
        //        await _fileService.DeleteImageAsync(item.ImagePath);
        //    }
        //}

        //return DbResult > 0;

    }

    public async Task<IList<BookViewModel>> GetAllAsync(PaginationParams @params)
    {
        var DbResult = await _repository.GetAllAsync(@params);
        var dBim = await _imageRepository.GetFirstAllAsync();

        List<BookViewModel> Result = new List<BookViewModel>();

        foreach (var item in DbResult)
        {
            item.BookImages = new List<BookImage>();

            foreach (var img in dBim)
            {
                if (img.BookId == item.Id)
                {
                    item.BookImages.Add(img);
                    item.MainImage = img.ImagePath;
                    dBim.RemoveAt(0);
                    break;
                }
            }

            Result.Add(item);
        }

        var DBCount = await _repository.CountAsync();
        _paginator.Paginate(DBCount, @params);

        return Result;


    }

    public async Task<BookViewModel> GetByIdAsync(long bookId)
    {
        var item = await _repository.GetByIdAsync(bookId);
        var dBim = await _imageRepository.GetByIdAllAsync(bookId);

        if (item.Id == 0)
            throw new BookNotFoundException();


        item.BookImages = new List<BookImage>();

        foreach (var img in dBim)
        {
            if (img.BookId == item.Id)
            {
                item.BookImages.Add(img);
            }
        }

        return item;
    }

    public Task<(long IteamCount, List<BookViewModel>)> SearchAsync(string search)
    {
        //var DbResult = await _repository.SearchAsync(search);

        //if (DbResult.ItemsCount == 0)
        //{
        //    List<BookViewModel> empty = new List<BookViewModel>();
        //    return (0, empty);
        //}

        //var dBim = await _imageRepository.GetFirstAllAsync();

        //List<BookViewModel> Result = new List<BookViewModel>();

        //foreach (var item in DbResult.Item2)
        //{
        //    item.BookImages = new List<BookImage>();

        //    foreach (var img in dBim)
        //    {
        //        if (img.BookId == item.Id)
        //        {
        //            item.BookImages.Add(img);
        //            item.MainImage = img.ImagePath;
        //            dBim.RemoveAt(0);
        //            break;
        //        }
        //    }

        //    Result.Add(item);


        //    return (DbResult.ItemsCount, Result);
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(long bookId, BookUpdateDto dto)
    {
        var DbFound = await _repository.GetByIdAsync(bookId);

        if (DbFound.Id == 0)
            throw new BookNotFoundException();

        Book book = new Book()
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            CategoryId = dto.CategoryId,
            IsHardCover = dto.IsHardCover,
            CreatedAt = DbFound.CreatedAt,
            UpdatedAt = TimeHelper.GetDateTime(),
        };

        var DbResult = await _repository.UpdateAsync(bookId, book);

        if (DbResult > 0)
            return true;

        return false;
    }
}
