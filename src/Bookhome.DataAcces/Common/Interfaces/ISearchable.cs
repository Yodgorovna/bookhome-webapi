using Bookhome.Application.Utils;

namespace Bookhome.DataAcces.Common.Interfaces;

public interface ISearchable<TModel>
{
    public Task<(int ItemsCount, IList<TModel>)> SearchAsync(string search);
}
