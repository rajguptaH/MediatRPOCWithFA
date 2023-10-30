using System.Data;
using System.Data.Common;
using Microsoft.Extensions.Configuration;


namespace WebBuisness.Infrastructure
{
    /// <summary>
    /// Implimenting Connectionfactory for establishing connection with databsase
    /// </summary>
    public class ConnectionFactory : IConnectionFactory
    {
        private static IConfiguration _configuration;
        /// <summary>
        /// configaring with connectionfactory
        /// </summary>
        /// <param name="configuration"></param>

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Database Connection
        /// </summary>
        
        public IDbConnection GetConnection
        {
            get
            {
                {
                    DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
                    var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                    var conn = factory.CreateConnection();
                    if (conn == null) return null;
                    conn.ConnectionString = _configuration["ConnectionStrings:IdentityDBLocal"];
                    conn.Open();
                    return conn;
                }
            }
        }
    }
}
