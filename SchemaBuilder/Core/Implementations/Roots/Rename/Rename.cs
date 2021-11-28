using SchemaBuilder.Core.Implementations.Operations.Rename;
using SchemaBuilder.Core.Interfaces.Contracts.Operations.Rename;
using SchemaBuilder.Core.Interfaces.Contracts.Roots.Rename;
using SchemaBuilder.Core.Interfaces.DataHolders.Base;
using SchemaBuilder.Core.Interfaces.DataHolders.Roots;

namespace SchemaBuilder.Core.Implementations.Roots.Rename
{
    public class Rename : IRenameContract, IRootDataHolder
    {
        public List<IDataHolder> Children => new List<IDataHolder>();

        public IRenameColumnContract Column(string columnName)
        {
            RenameColumn renameColumn = new RenameColumn(columnName);
            Children.Add(renameColumn);
            return renameColumn;
        }

        public IRenameTableContract Table(string tableName)
        {
            RenameTable renameTable = new RenameTable(tableName);
            Children.Add(renameTable);
            return renameTable;
        }
    }
}
