using E_PrFinance.Data.Repositories;
using E_PrFinance.Domain.Entities;
using E_PrFinance.Service.DTOs;
using E_PrFinance.Service.Helpers;
using E_PrFinance.Service.Interfaces;
using System;

namespace E_PrFinance.Service.Services;

public class DetailService : IDetailService
{
    private readonly Repository<WalletDetail> genericRepository = new Repository<WalletDetail>();
    public async Task<Response<WalletDetail>> CreateAsync(DetailCreationDto detail)
    {
        var results = await this.genericRepository.GetAllAsync();
        var result = results.FirstOrDefault(x => x.Name.ToLower() == detail.Name.ToLower());
        if (result is not null)
        {
            return new Response<WalletDetail>()
            {
                StatusCode = 403,
                Message = "This wallet is already  exists!",
                ResultResponse = null
            };
        }
        var Wallet = new WalletDetail()
        {
            Name = detail.Name,
            CurrencyType = detail.CurrencyType,
            Id = detail.UserId
        };

        var Result = await this.genericRepository.CreateAsync(Wallet);

        return new Response<WalletDetail>()
        {
            StatusCode = 200,
            Message = "Success",
            ResultResponse = Result
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var result = await this.genericRepository.GetByIdAsync(p => p.Id == id);
        if (result is not null)
        {
            await this.genericRepository.DeleteAsync(p => p.Id == id);
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
            Message = "Details are not found",
            ResultResponse = false
        };
    }

    public async Task<Response<List<WalletDetail>>> GetAllAsync(Predicate<WalletDetail> predicate)
    {
        var results = await this.genericRepository.GetAllAsync();
        return new Response<List<WalletDetail>>()
        {
            StatusCode = 200,
            Message = "Success",
            ResultResponse = results
        };
    }

    public async Task<Response<WalletDetail>> GetAsync(Predicate<MonthlyIncome> predicate)
    {
        var result = await this.genericRepository.GetByIdAsync();
        if (result is null)
        {
            return new Response<WalletDetail>()
            {
                StatusCode = 404,
                Message = "Detail is not found",
                ResultResponse = null
            };
        }
        return new Response<WalletDetail>()
        {
            StatusCode = 200,
            Message = "Success",
            ResultResponse = result
        };
    }

    public async Task<Response<WalletDetail>> UpdateAsync(long id, DetailCreationDto detail)
    {
        var result = await this.genericRepository.GetByIdAsync(x => x.Id == Id);
        if (result is not null)
        {
            var newWallet = new WalletDetail()
            {
                Id = result.Id,
                Name = detail.Name,
                Amount = detail.Amount,
                CurrencyType = detail.CurrencyType,
                Id = result.UserId,
                CreatedAt = result.CreatedAt,
                UpdatedAt = DateTime.Now,
            };

            await this.genericRepository.UpdateAsync(x => x.Id == id, newWallet);

            return new Response<WalletDetail>()
            {
                StatusCode = 200,
                Message = "Successfully updated",
                ResultResponse = result
            };
        }
        return new Response<WalletDetail>()
        {
            StatusCode = 404,
            Message = "Wallet is not found",
            ResultResponse = null
        };
    }
}
