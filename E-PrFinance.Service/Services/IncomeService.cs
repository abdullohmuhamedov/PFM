using E_PrFinance.Data.Repositories;
using E_PrFinance.Domain.Entities;
using E_PrFinance.Service.DTOs;
using E_PrFinance.Service.Helpers;
using E_PrFinance.Service.Interfaces;

namespace E_PrFinance.Service.Services;

public class IncomeService : IIncomeService
{
    private readonly Repository<MonthlyIncome> genericRepository = new Repository<MonthlyIncome>();
    public async Task<Response<MonthlyIncome>> CreateAsync(IncomeCreationDto income)
    {
        var newIncome = new MonthlyIncome()
        {
            AmountMoney = income.Amount,
            Description = income.Description,
            Id = income.WalletId,
        };
        var result = await this.genericRepository.CreateAsync(newIncome);

        return new Response<MonthlyIncome>()
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
        if (result is not null)
        {
            await this.genericRepository.DeleteAsync(x => x.Id == id);

            return new Response<bool>()
            {
                StatusCode = 200,
                Message = "Successfully deleted",
                ResultResponse = true
            };
        }
        return new Response<bool>()
        {
            StatusCode = 404,
            Message = "Income is not found",
            ResultResponse = false
        };
    }

    public async Task<Response<List<MonthlyIncome>>> GetAllAsync(Predicate<MonthlyIncome> predicate)
    {
        var results = await this.genericRepository.GetAllAsync();
        return new Response<List<MonthlyIncome>>()
        {
            StatusCode = 200,
            Message = "Successfully founded",
            ResultResponse = results
        };
    }

    public async Task<Response<MonthlyIncome>> GetAsync(Predicate<MonthlyIncome> predicate)
    {
        var result = await this.genericRepository.GetByIdAsync(predicate);
        if (result is null)
        {
            return new Response<MonthlyIncome>()
            {
                StatusCode = 404,
                Message = "Income is not found",
                ResultResponse = null
            };
        }
        return new Response<MonthlyIncome>()
        {
            StatusCode = 200,
            Message = "Successfully found",
            ResultResponse = result
        };
    }

    public async Task<Response<MonthlyIncome>> UpdateAsync(long id, IncomeCreationDto income)
    {
        var result = await this.genericRepository.GetByIdAsync(x => x.Id == id);
        if (result is null)
        {
            return new Response<MonthlyIncome>()
            {
                StatusCode = 404,
                Message = "Income is not found",
                ResultResponse = null
            };
        }

        var newIncome = new MonthlyIncome()
        {
            Id = result.Id,
            Description = income.Description,
            AmountMoney = income.Amount,
            Id = income.WalletId,
            CreatedAt = result.CreatedAt,
            UpdatedAt = DateTime.Now,
        };

        await this.genericRepository.UpdateAsync(x => x.Id == id, newIncome);

        return new Response<MonthlyIncome>()
        {
            StatusCode = 200,
            Message = "Successfully updated",
            ResultResponse = result
        };
    }
}
