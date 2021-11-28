using SchemaBuilder.Core.Interfaces.Contracts.Operations.Rename;

namespace SchemaBuilder.Core.Interfaces.Contracts.Roots.Rename
{
    public interface IRenameContract
    {
        public IRenameTableContract Table(string tableName);

        public IRenameColumnContract Column(string columnName);
    }
}
