using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Hre.Api.Database
{
    public class SqlConnectionFactory
    {
        public static async Task<SqlConnection> Create()
        {
            var c= new SqlConnection(ConnectionString);
            await c.OpenAsync();
            return c;
        }

        internal static string ConnectionString;
    }
}