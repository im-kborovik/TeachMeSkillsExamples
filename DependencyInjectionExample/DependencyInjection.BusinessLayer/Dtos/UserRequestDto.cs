namespace DependencyInjection.BusinessLayer.Dtos;

public class UserRequestDto
{
    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }
}