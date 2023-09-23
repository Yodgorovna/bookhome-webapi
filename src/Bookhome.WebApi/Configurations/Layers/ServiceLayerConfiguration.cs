using Bookhome.Services.Interfaces.Auth;
using Bookhome.Services.Interfaces.Authors;
using Bookhome.Services.Interfaces.Books;
using Bookhome.Services.Interfaces.Categories;
using Bookhome.Services.Interfaces.Common;
using Bookhome.Services.Interfaces.Discounts;
using Bookhome.Services.Interfaces.Notifications;
using Bookhome.Services.Interfaces.Orders;
using Bookhome.Services.Interfaces.Users;
using Bookhome.Services.Services.Auth;
using Bookhome.Services.Services.Authors;
using Bookhome.Services.Services.Books;
using Bookhome.Services.Services.Categories;
using Bookhome.Services.Services.Common;
using Bookhome.Services.Services.Discounts;
using Bookhome.Services.Services.Notifications;
using Bookhome.Services.Services.Orders;
using Bookhome.Services.Services.Users;

namespace Bookhome.WebApi.Configurations.Layers;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISmsSender, SmsSender>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IPaginator, Paginator>();
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IIdentityService, IdentityService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IDiscountService, DiscountService>();
        builder.Services.AddScoped<IAuthorService, AuthorService>();
        builder.Services.AddScoped<IBookService, BookService>();
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IUserService, UserService>();
    }
     
}
