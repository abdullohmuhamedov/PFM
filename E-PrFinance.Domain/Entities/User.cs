using E_PrFinance.Domain.Commons;
using E_PrFinance.Domain.Enums;

namespace E_PrFinance.Domain.Entities; 

public class User : Auditable 
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public UserRole UserRole { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirmed { get; set; }
    public string Username { get; set; }
    
}
