using E_PrFinance.Domain.Commons;
using E_PrFinance.Domain.Enums;

namespace E_PrFinance.Domain.Entities; 

public class VirtualCard : Auditable 
{
    public OnlineCard OnlineCard { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Location { get; set; }
    public string Password { get; set; }

}
