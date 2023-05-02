using E_PrFinance.Data.Configurations;
using E_PrFinance.Data.IRepositories;
using E_PrFinance.Domain.Commons;
using E_PrFinance.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace E_PrFinance.Data.Repositories;

public class Repository<TResult> : IRepository<TResult> where TResult : Auditable
{
    private string path;

    public Repository()
    {
        if (typeof(TResult) == typeof(User))
        {
            path = DatabasePath.USER_PATH;
        }
        else if (typeof(TResult) == typeof(CurrencyConverter))
        {
            path = DatabasePath.CONVERTER_PATH;
        }
        else if (typeof(TResult) == typeof(MonthlyIncome))
        {
            path = DatabasePath.INCOME_PATH;
        }
        else if (typeof(TResult) == typeof(MonthlyExpense))
        {
            path = DatabasePath.EXPENSE_PATH;
        }
        else if (typeof(TResult) == typeof(VirtualCard))
        {
            path = DatabasePath.VIRTUAL_CARD_PATH;
        }
        else if (typeof(TResult) == typeof(WalletDetail))
        {
            path = DatabasePath.DETAIL_PATH;
        }
    }
    public async Task<TResult> CreateAsync(TResult value)
    {
        var students = await GetAllAsync();
        students.Add(value);

        var json = JsonConvert.SerializeObject(students, Formatting.Indented);
        await File.WriteAllTextAsync(path, json);

        return value;
    }

    public async Task<bool> DeleteAsync(Predicate<TResult> predicate)
    {
        var students = await GetAllAsync();
        var student = students.FirstOrDefault(p => p.Id == id);

        if (student is null)
            return false;

        students.Remove(student);

        var json = JsonConvert.SerializeObject(students, Formatting.Indented);
        await File.WriteAllTextAsync(path, json);
        return true;
    }

    public async Task<List<TResult>> GetAllAsync()
    {
        var models = await File.ReadAllTextAsync(path);
        if (string.IsNullOrEmpty(models))
            models = "[]";
        var json = JsonConvert.DeserializeObject<List<TResult>>(models);
        return json;
    }

    public async Task<TResult> GetByIdAsync(Predicate<TResult> predicate)
    {
        var students = await GetAllAsync();
        var student = students.FirstOrDefault(p => p.Id == id);
        if (student is null)
            return null;
        return student;
    }

    public async Task<TResult> UpdateAsync(Predicate<TResult> predicate, TResult value)
    {
        var students = await GetAllAsync();
        var model = students.FirstOrDefault(p => p.Id == id);
        var index = students.IndexOf(model);

        students.Insert(index, value);
        var json = JsonConvert.SerializeObject(students, Formatting.Indented);
        await File.WriteAllTextAsync(path, json);

        return value;
    }
}
