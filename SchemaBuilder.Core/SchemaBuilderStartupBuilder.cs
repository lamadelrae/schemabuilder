using System.Data;

namespace SchemaBuilder.Core
{
    public class SchemaBuilderStartupBuilder
    {
        private IDbConnection? _dbConnection;

        public SchemaBuilderStartupBuilder UseSchemaBuilder(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            return this;
        }
    }
}
