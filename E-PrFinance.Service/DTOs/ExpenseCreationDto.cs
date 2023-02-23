namespace E_PrFinance.Service.DTOs; 

public class ExpenseCreationDto 
{
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public long WalletId { get; set; }
}
