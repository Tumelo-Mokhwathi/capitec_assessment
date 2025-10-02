using CSharpFunctionalExtensions;

namespace small_business_invoice_tracker.Services.Interfaces
{
    public interface IGenericService<TModel, TKey>
    {
        Task<TModel> GetByIdAsync(TKey id);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<Result<TModel>> CreateAsync(TModel entity);
        Task<Result<TModel>> UpdateAsync(TKey id, TModel entity);
        Task<Result<TModel>> DeleteAsync(TKey id);
    }
}
