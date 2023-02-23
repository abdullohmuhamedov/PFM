using E_PrFinance.Domain.Enums;

namespace E_PrFinance.Service.DTOs; 

public class DetailCreationDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public long UserId { get; set; }
    public CurrencyType CurrencyType { get; set; }
    public decimal Amount { get; set; }

}
