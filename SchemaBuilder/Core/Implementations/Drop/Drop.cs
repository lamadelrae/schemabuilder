using SchemaBuilder.Core.Interfaces.Drop;

namespace SchemaBuilder.Core.Implementations.Drop
{
    public class Drop : IDrop
    {
        public IDropTable DropTable { get; private set; }

        public IDropColumn DropColumn { get; private set; }

        public IDropColumn Column(string columnName)
        {
            DropColumn = new DropColumn();
            return DropColumn;
        }

        public IDropTable Table(string tableName)
        {
            DropTable = new DropTable();
            return DropTable;
        }
    }
}
