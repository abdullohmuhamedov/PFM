using E_PrFinance.Domain.Commons;

namespace E_PrFinance.Domain.Entities; 

public class CurrencyConverter : Auditable
{
    public decimal Limit { get; set; }
}
