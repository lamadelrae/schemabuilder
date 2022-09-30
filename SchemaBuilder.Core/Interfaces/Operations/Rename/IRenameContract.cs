using SchemaBuilder.Core.Interfaces.Operations.Rename.Column;
using SchemaBuilder.Core.Interfaces.Operations.Rename.Table;

namespace SchemaBuilder.Core.Interfaces.Operations.Rename
{
    public interface IRenameContract
    {
        IRenameTableContract Table(string tableName);

        IRenameColumnContract Column(string columnName);
    }
}
