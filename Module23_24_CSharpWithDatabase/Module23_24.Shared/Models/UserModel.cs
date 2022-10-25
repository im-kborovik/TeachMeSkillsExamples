using System;

namespace Module23_24.Shared.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}