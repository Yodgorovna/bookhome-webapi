using Bookhome.DataAcces.Interfaces.Authors;
using Bookhome.DataAcces.Interfaces.Books;
using Bookhome.DataAcces.Interfaces.Categories;
using Bookhome.DataAcces.Interfaces.Discounts;
using Bookhome.DataAcces.Interfaces.Orders;
using Bookhome.DataAcces.Interfaces.Users;
using Bookhome.DataAcces.Repositories.Authors;
using Bookhome.DataAcces.Repositories.Books;
using Bookhome.DataAcces.Repositories.Categories;
using Bookhome.DataAcces.Repositories.Discounts;
using Bookhome.DataAcces.Repositories.Orders;
using Bookhome.DataAcces.Repositories.Users;

namespace Bookhome.WebApi.Configurations.Layers
{
    public static class DataAccessConfiguration
    {
        public static void ConfigureDataAccess(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IBookImageRepository, BookImageRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
