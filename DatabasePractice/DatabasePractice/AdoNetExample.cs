using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DatabasePractice
{
    public class AdoNetExample
    {
        public async Task MakeAdoNet()
        {
            var connectionString = "Server=localhost;Database=AdoNetExample;Trusted_Connection=True;Encrypt=False;";
            using var sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            var getUsersSql = "select * from Users";
            var sqlCommand = new SqlCommand(getUsersSql, sqlConnection);
            var dataReader = await sqlCommand.ExecuteReaderAsync();

            while (await dataReader.ReadAsync())
            {
                var userId = dataReader.GetFieldValue<int>("UserId");
                var firstName = dataReader.GetFieldValue<string>("FirstName");
                var lastName = dataReader.GetFieldValue<string>("LastName");
                var birthDate = dataReader.IsDBNull("BirthDate")
                                    ? null
                                    : dataReader.GetFieldValue<DateTime?>("BirthDate");

                Console.WriteLine($"{userId} {firstName} {lastName} {birthDate}");
            }
        }
    }
}