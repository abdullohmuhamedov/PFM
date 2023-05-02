//using E_PrFinance.Data.Repositories;
//using E_PrFinance.Domain.Entities;
//using E_PrFinance.Service.DTOs;
//using E_PrFinance.Service.Helpers;
//using E_PrFinance.Service.Interfaces;
//using System;

//namespace E_PrFinance.Service.Services;

//public class UserService : IUserService
//{
//    private readonly Repository<User> genericRepository = new Repository<User>();
//    public async Task<Response<User>> CreateAsync(UserCreationDto user)
//    {
//        var models = await this.genericRepository.GetAllAsync();
//        var model = models.FirstOrDefault(u => u.Email == user.Email);
//        if (models is null)
//        {
//            var newModel = new User()
//            {
//                FirstName = user.FirstName,
//                LastName = user.LastName,
//                Email = user.Email,
//                Password = user.Password
//            };
//            var Result = await this.genericRepository.CreateAsync(newModel);

//            return new Response<User>()
//            {
//                StatusCode = 200,
//                Message = "Successfully added",
//                ResultResponse = Result
//            };
//        }
//        return new Response<User>()
//        {
//            StatusCode = 403,
//            Message = "Already exists",
//            ResultResponse = null
//        };
//    }

//    public async Task<Response<bool>> DeleteAsync(long id)
//    {
//        var result = await this.genericRepository.DeleteAsync(id);
//        if (result is null)
//        {
//            return new Response<bool>()
//            {
//                StatusCode = 404,
//                Message = "User not found",
//                ResultResponse = false
//            };
//        }
//        await this.genericRepository.DeleteAsync(id);
//        return new Response<bool>()
//        {
//            StatusCode = 200,
//            Message = "Successfully deleted",
//            ResultResponse = true
//        };
//    }

//    public async Task<Response<List<User>>> GetAllAsync()
//    {
//        var results = await this.genericRepository.GetAllAsync();
//        return new Response<Response<User>>()

//        {
//            StatusCode = 200,
//            Message = "Success",
//            ResultResponse = results
//        };
//    }

//    public async Task<Response<User>> GetAsync(long id)
//    {
//        var result = await this.genericRepository.GetAllAsync();
//        if (result is null)
//        {
//            return new Response<User>()
//            {
//                StatusCode = 404,
//                Message = "NOT FOUND",
//                ResultResponse = null
//            };
//        }
//        return new Response<User>()
//        {
//            StatusCode = 200,
//            Message = "Success",
//            ResultResponse = result
//        };
//    }

//    public async Task<Response<User>> UpdateAsync(long id, UserCreationDto user)
//    {
//        var result = await this.genericRepository.GetAllAsync();
//        if (result is null)
//        {
//            return new Response<User>()
//            {
//                StatusCode = 404,
//                Message = "User is not found",
//                ResultResponse = null
//            };
//        }

//        var newUser = new User()
//        {
//            FirstName = user.FirstName,
//            LastName = user.LastName,
//            Email = user.Email,
//            Password = user.Password,
//            UpdatedAt = DateTime.Now,
//        };

//        await this.genericRepository.UpdateAsync(newUser);

//        return new Response<User>()
//        {
//            StatusCode = 200,
//            Message = "Successfully updated",
//            ResultResponse = result
//        };
//    }
//}