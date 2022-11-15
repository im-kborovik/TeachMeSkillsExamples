﻿namespace DependencyInjection.Entities.Users;

public class User
{
    public Guid UserId { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public string Email { get; set; }
}