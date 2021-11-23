using SchemaBuilder.Core.Interfaces.Base;
using SchemaBuilder.Core.Interfaces.Drop;

namespace SchemaBuilder.Core.Implementations.Drop
{
    public class Drop : IDrop
    {
        public List<IOperation> Operations => new List<IOperation>();

        public IDropColumn Column(string columnName)
        {
            var dropColumn = new DropColumn(columnName);
            Operations.Add(dropColumn);
            return dropColumn;
        }

        public IDropTable Table(string tableName)
        {
            var dropTable = new DropTable(tableName);
            Operations.Add(dropTable);
            return dropTable;
        }
    }
}
