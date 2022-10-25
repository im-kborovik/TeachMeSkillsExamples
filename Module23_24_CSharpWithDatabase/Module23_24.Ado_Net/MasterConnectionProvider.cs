using Microsoft.Extensions.Configuration;
using Module23_24.Ado_Net.Interfaces;

namespace Module23_24.Ado_Net
{
    public class MasterConnectionProvider : DefaultConnectionProvider, IMasterConnectionProvider
    {
        protected override string ConnectionString => Configuration.GetConnectionString("MasterConnection");

        public MasterConnectionProvider(IConfiguration configuration) : base(configuration)
        {
        }
    }
}