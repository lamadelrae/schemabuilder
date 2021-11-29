using System.Data.SqlClient;

namespace SchemaBuilder.Tests.Unit.DispatcherTests
{
    public class DispatcherTests
    {
        public void ShouldAddColumn()
        {
            SchemaBuilder.UseSchemaBuilder(new SqlConnection())
        }
    }
}
