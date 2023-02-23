using E_PrFinance.Domain.Entities;
using E_PrFinance.Service.DTOs;
using E_PrFinance.Service.Helpers;

namespace E_PrFinance.Service.Interfaces; 

public interface IDetailService 
{
    Task<Response<WalletDetail>> CreateAsync(DetailCreationDto detail);
    Task<Response<WalletDetail>> UpdateAsync(long id, DetailCreationDto detail);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<WalletDetail>> GetAsync(Predicate<WalletDetail> predicate);
    Task<Response<List<WalletDetail>>> GetAllAsync(Predicate<WalletDetail> predicate);
}
