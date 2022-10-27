using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DatabasePractice
{
    public class EntityFrameworkExample
    {
        public async Task MakeEf()
        {
            var connectionString = "Server=localhost;Database=AdoNetExample;Trusted_Connection=True;Encrypt=False;";
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(connectionString);
            
            using var context = new MyDbContext(builder.Options);

            var users = await context.Users.ToArrayAsync();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.UserId} {user.FirstName} {user.LastName} {user.BirthDate}");
            }
        }
    }
}