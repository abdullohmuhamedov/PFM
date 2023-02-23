namespace E_PrFinance.Data.IRepositories;

public interface IGenericRepository<TResult>
{
    Task<TResult> CreateAsync(TResult value);
    Task<TResult> UpdateAsync(Predicate<TResult> predicate, TResult value);
    Task<bool> DeleteAsync(Predicate<TResult> predicate);
    Task<TResult> GetByIdAsync(long id, Predicate<TResult> predicate);
    Task<List<TResult>> GetAllAsync(Predicate<TResult> predicate);
}
