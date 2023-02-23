using E_PrFinance.Domain.Enums;

namespace E_PrFinance.Service.DTOs;

public class VirtualCardCreationDto
{
    public OnlineCard OnlineCard { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}
