using SchemaBuilder.Core.Interfaces.Drop;

namespace SchemaBuilder.Core.Implementations.Drop
{
    internal class DropTable : IDropTable 
    {
        public string TableName { get; private set; }  

        public DropTable(string tableName)
        {
            TableName = tableName;
        }
    }
}
