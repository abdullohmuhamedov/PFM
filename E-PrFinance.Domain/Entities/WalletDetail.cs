using E_PrFinance.Domain.Commons;
using E_PrFinance.Domain.Enums;

namespace E_PrFinance.Domain.Entities; 

public class WalletDetail : Auditable
{
    public string Name { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal TotalExpense { get; set; }
    public decimal Amount { get; set; }
    public CurrencyType CurrencyType { get; set; }
    public string Description { get; set; }

}
