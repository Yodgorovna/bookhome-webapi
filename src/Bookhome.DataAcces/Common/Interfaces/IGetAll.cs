using Bookhome.Application.Utils;

namespace Bookhome.DataAcces.Common.Interfaces;

public interface IGetAll<TModel>
{
    public Task<IList<TModel>> GetAllAsync(PaginationParams @params);
}
