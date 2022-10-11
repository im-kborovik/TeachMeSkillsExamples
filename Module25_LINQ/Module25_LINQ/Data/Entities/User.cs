namespace Module25_LINQ.Data.Entities;

public class User
{
    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age => DateTime.UtcNow.Year - BirthDate.Year;

    public DateTime BirthDate { get; set; }

    public Address Address { get; set; }

    public override string ToString()
    {
        return $"{nameof(Email)}: {Email}; {nameof(FirstName)}: {FirstName}; {nameof(LastName)}: {LastName}; "
               + $"{nameof(Age)}: {Age}; {nameof(BirthDate)}: {BirthDate}";
    }
}