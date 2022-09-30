using SchemaBuilder.Core.Interfaces.Operations;
using SchemaBuilder.Core.Interfaces.Operations.Drop;
using SchemaBuilder.Core.Interfaces.Operations.Drop.Column;
using SchemaBuilder.Core.Operations.Drop.Column;
using SchemaBuilder.Core.Operations.Drop.Table;

namespace SchemaBuilder.Core.Operations.Drop
{
    public class Drop : IDropContract, IBaseDataStore
    {
        public Queue<IDataStore> Children { get; private set; } = new Queue<IDataStore>();

        public IDropColumnContract Column(string columnName)
        {
            var dropColumn = new DropColumn(columnName);
            Children.Enqueue(dropColumn);
            return dropColumn;
        }

        public IDropTableContract Table(string tableName)
        {
            var dropTable = new DropTable(tableName);
            Children.Enqueue(dropTable);
            return dropTable;
        }
    }
}
