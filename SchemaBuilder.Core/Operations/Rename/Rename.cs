using SchemaBuilder.Core.Interfaces.Operations;
using SchemaBuilder.Core.Interfaces.Operations.Rename;
using SchemaBuilder.Core.Interfaces.Operations.Rename.Column;
using SchemaBuilder.Core.Interfaces.Operations.Rename.Table;
using SchemaBuilder.Core.Operations.Rename.Column;
using SchemaBuilder.Core.Operations.Rename.Table;

namespace SchemaBuilder.Core.Operations.Rename
{
    public class Rename : IRenameContract, IBaseDataStore
    {
        public Queue<IDataStore> Children { get; } = new Queue<IDataStore>();

        public IRenameColumnContract Column(string columnName)
        {
            var renameColumn = new RenameColumn(columnName);
            Children.Enqueue(renameColumn);
            return renameColumn;
        }

        public IRenameTableContract Table(string tableName)
        {
            var renameTable = new RenameTable(tableName);
            Children.Enqueue(renameTable);
            return renameTable;
        }
    }
}
