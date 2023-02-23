using E_PrFinance.Data.Repositories;
using E_PrFinance.Domain.Entities;
using E_PrFinance.Service.DTOs;
using E_PrFinance.Service.Helpers;
using E_PrFinance.Service.Interfaces;

namespace E_PrFinance.Service.Services;

public class ExpenseService : IExpenseService
{
    private readonly GenericRepository<MonthlyExpense> genericRepository = new GenericRepository<MonthlyExpense>();
    public async Task<Response<MonthlyExpense>> CreateAsync(ExpenseCreationDto expense)
    {
        var newExpense = new MonthlyExpense()
        {
            AmountOfExpenses = expense.Amount,
            Description = expense.Description,
            Id = expense.WalletId,
        };

        var result = await this.genericRepository.CreateAsync(newExpense);

        return new Response<MonthlyExpense>()
        {
            StatusCode = 200,
            Message = "Success",
            ResultResponse = result
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var result = await this.genericRepository.GetByIdAsync(x => x.Id == id);
        var amount = result.Amount;
        if (result is null)
        {
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "Expense is not found",
                ResultResponse = false
            };
        }
        await this.genericRepository.DeleteAsync(x => x.Id == id);

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Successfully deleted",
            ResultResponse = true
        };
    }

    public async Task<Response<List<MonthlyExpense>>> GetAllAsync(Predicate<MonthlyExpense> predicate)
    {
        var results = await this.genericRepository.GetAllAsync(predicate);
        return new Response<List<MonthlyExpense>>()
        {
            StatusCode = 200,
            Message = "Successfully found",
            ResultResponse = results
        };
    }

    public async Task<Response<MonthlyExpense>> GetAsync(Predicate<MonthlyExpense> predicate)
    {
        var result = await this.genericRepository.GetByIdAsync(predicate);
        if (result is null)
        {
            return new Response<MonthlyExpense>()
            {
                StatusCode = 404,
                Message = "Expense is not found",
                ResultResponse = null
            };
        }
        return new Response<MonthlyExpense>()
        {
            StatusCode = 200,
            Message = "Successfully found",
            ResultResponse = result
        };
    }

    public async Task<Response<MonthlyExpense>> UpdateAsync(long id, ExpenseCreationDto expense)
    {
        var result = await this.genericRepository.GetByIdAsync(x => x.Id == id);
        if (result is null)
        {
            return new Response<MonthlyExpense>()
            {
                StatusCode = 404,
                Message = "NOT FOUND",
                ResultResponse = null
            };
        }

        var newExpense = new MonthlyExpense()
        {
            Id = result.Id,
            Description = expense.Description,
            AmountOfExpenses = expense.Amount,
            Id = expense.WalletId,
            CreatedAt = result.CreatedAt,
            UpdatedAt = DateTime.Now,
        };

        await this.genericRepository.UpdateAsync(x => x.Id == id, newExpense);

        return new Response<MonthlyExpense>()
        {
            StatusCode = 200,
            Message = "Success",
            ResultResponse = result
        };
    }
}
