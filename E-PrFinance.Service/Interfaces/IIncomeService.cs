using E_PrFinance.Domain.Entities;
using E_PrFinance.Service.DTOs;
using E_PrFinance.Service.Helpers;

namespace E_PrFinance.Service.Interfaces;

public interface IIncomeService
{
    Task<Response<MonthlyIncome>> CreateAsync(IncomeCreationDto income);
    Task<Response<MonthlyIncome>> UpdateAsync(long id, IncomeCreationDto income);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<MonthlyIncome>> GetAsync(Predicate<MonthlyIncome> predicate);
    Task<Response<List<MonthlyIncome>>> GetAllAsync(Predicate<MonthlyIncome> predicate);
}
