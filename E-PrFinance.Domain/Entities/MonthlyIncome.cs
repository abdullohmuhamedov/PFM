using E_PrFinance.Domain.Commons;
using E_PrFinance.Domain.Enums;

namespace E_PrFinance.Domain.Entities; 

public class MonthlyIncome : Auditable
{
    public decimal AmountMoney { get; set; }
    public CurrencyType Type { get; set; }
    public string Description { get; set; }
}
