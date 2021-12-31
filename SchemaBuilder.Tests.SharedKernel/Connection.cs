using System.Data.SqlClient;

namespace SchemaBuilder.Tests.SharedKernel
{
    public static class Connection
    {
        public static SqlConnection Get()
        {
            return new SqlConnection("Server=localhost\\sql2019;Database=SchemaBuilder;User Id=sa;Password=Pass*12345678;");
        }
    }
}
