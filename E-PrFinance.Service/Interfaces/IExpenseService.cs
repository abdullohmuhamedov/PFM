using E_PrFinance.Domain.Entities;
using E_PrFinance.Service.DTOs;
using E_PrFinance.Service.Helpers;

namespace E_PrFinance.Service.Interfaces; 

public interface IExpenseService 
{
    Task<Response<MonthlyExpense>> CreateAsync(ExpenseCreationDto expense);
    Task<Response<MonthlyExpense>> UpdateAsync(long id, ExpenseCreationDto expense);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<MonthlyExpense>> GetAsync(Predicate<MonthlyExpense> predicate);
    Task<Response<List<MonthlyExpense>>> GetAllAsync(Predicate<MonthlyExpense> predicate);
}
