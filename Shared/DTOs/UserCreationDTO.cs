using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DTOs;

public class UserCreationDTO
{
    public string UserName { get;}
    public string Password { get; }
    
    public DateTime Dob { get; }
    
    public string Email { get; }
    
    public string Role { get; }

    public UserCreationDTO(string userName, string password, DateTime dob, string email, string role)
    {
        UserName = userName;
        Password = password;
        Dob = dob;
        Email = email;
        Role = role;
    }

  
}