using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DatabasePractice
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var adoNetExample = new AdoNetExample();
            await adoNetExample.MakeAdoNet();
            
            var entityFrameworkExample = new EntityFrameworkExample();
            await entityFrameworkExample.MakeEf();
        }
    }
}