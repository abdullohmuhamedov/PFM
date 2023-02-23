namespace E_PrFinance.Service.DTOs;

public class IncomeCreationDto
{
    public decimal Amount { get; set; }
    public long WalletId { get; set; }
    public string Description { get; set; }
}
