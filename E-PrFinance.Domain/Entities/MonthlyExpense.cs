using E_PrFinance.Domain.Commons;
using E_PrFinance.Domain.Enums;

namespace E_PrFinance.Domain.Entities; 

public class MonthlyExpense : Auditable 
{
    public decimal AmountOfExpenses { get; set; }
    public string Description { get; set; }
    public CurrencyType TypeOfCurrency { get; set; }
}
