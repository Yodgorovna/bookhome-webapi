using Bookhome.Application.Utils;

namespace Bookhome.DataAcces.Interfaces;

public interface IRepository<TEntity, TViewModel>
{
    public Task<int> CreateAsync(TEntity entity);    

    public Task<int> UpdateAsync(long Id, TEntity entity);   
    
    public Task<int> DeleteAsync(long Id);

    public Task<List<TViewModel>> GetAllAsync(PaginationParams @params);

    public Task<long> CountAsync();

}
