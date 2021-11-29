using SchemaBuilder.Core.Interfaces.Contracts.Operations.Drop;
using SchemaBuilder.Core.Interfaces.Contracts.Roots.Drop;
using SchemaBuilder.Core.Interfaces.DataHolders.Base;
using SchemaBuilder.Core.Interfaces.DataHolders.Roots;
using SchemaBuilder.Core.Implementations.Operations.Drop;

namespace SchemaBuilder.Core.Implementations.Roots.Drop
{
    public class Drop : IDropContract, IRootDataHolder
    {
        public List<IDataHolder> Children { get; private set; } = new List<IDataHolder>();

        public IDropColumnContract Column(string columnName)
        {
            var dropColumn = new DropColumn(columnName);
            Children.Add(dropColumn);
            return dropColumn;
        }

        public IDropTableContract Table(string tableName)
        {
            var dropTable = new DropTable(tableName);
            Children.Add(dropTable);
            return dropTable;
        }
    }
}
