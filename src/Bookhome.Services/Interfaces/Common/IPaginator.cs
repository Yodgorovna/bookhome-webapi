using Bookhome.Application.Utils;

namespace Bookhome.Services.Interfaces.Common;

public interface IPaginator
{
    public void Paginate(long itemsCount, PaginationParams @params);
}
