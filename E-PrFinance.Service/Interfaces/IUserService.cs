using E_PrFinance.Domain.Entities;
using E_PrFinance.Service.DTOs;
using E_PrFinance.Service.Helpers;

namespace E_PrFinance.Service.Interfaces;

public interface IUserService
{
    Task<Response<User>> CreateAsync(UserCreationDto user);
    Task<Response<User>> UpdateAsync(long id, UserCreationDto user);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<User>> GetAsync(long id);
    Task<Response<List<User>>> GetAllAsync();
}
