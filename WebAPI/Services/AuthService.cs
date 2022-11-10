using System.ComponentModel.DataAnnotations;
using Shared.Models;

namespace WebApi.Services;

public class AuthService : IAuthService
{

    private readonly IList<User> users = new List<User>
    {
        new User
        {
            DOB = new DateTime(2010, 1, 1),
            Email = "wojcheck@via.dk",
            Name = "Woj Check",
            Password = "idontSMOKE",
            Role = "Teacher",
            UserName = "WCH",
            SecurityLevel = 4
        },
        new User
        {
            DOB = new DateTime(2001,5,26),
            Email = "anca@gmail.com",
            Name = "Anca Bugashvili",
            Password = "ILoveHorsens",
            Role = "Student",
            UserName = "aeb",
            SecurityLevel = 2
        }
    };

    public Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = users.FirstOrDefault(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingUser);
    }

    public Task RegisterUser(User user)
    {

        if (string.IsNullOrEmpty(user.UserName))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here
        
        // save to persistence instead of list
        
        users.Add(user);
        
        return Task.CompletedTask;
    }
}