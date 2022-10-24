namespace Module23_24.Shared
{
    public static class ConnectionStrings
    {
        public const string DatabaseName = "AdoDotNetExample";
        public const string MasterDatabase = "master";
        public const string SqlDatabaseConnectionDefault = "Server=localhost;Database=" + DatabaseName + ";Trusted_Connection=True;Encrypt=False;TrustServerCertificate=False;";
        public const string SqlDatabaseConnectionMaster = "Server=localhost;Database=" + MasterDatabase + ";Trusted_Connection=True;Encrypt=False;TrustServerCertificate=False;";
    }
}