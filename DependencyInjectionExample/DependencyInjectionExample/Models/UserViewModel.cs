using System;
using System.ComponentModel.DataAnnotations;

namespace DependencyInjectionExample.Models;

public class UserViewModel
{
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    [MaxLength(100)]
    public string Email { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName} {Email} {BirthDate:d}";
    }
}