using System.Data.SqlClient;
using Xunit;

namespace SchemaBuilder.Tests.Unit.DispatcherTests
{
    public class DispatcherTests
    {
        [Fact]
        public void ShouldAddColumn()
        {
            SchemaBuilder.UseSchemaBuilder(new SqlConnection());
        }
    }
}
