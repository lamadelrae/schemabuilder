using SchemaBuilder.Core.Interfaces.Base;
using SchemaBuilder.Core.Interfaces.Rename;

namespace SchemaBuilder.Core.Implementations.Rename
{
    public class Rename : IRename
    {
        public List<IOperation> Operations => throw new NotImplementedException();

        public IRenameColumn Column(string columnName)
        {
            RenameColumn renameColumn = new RenameColumn(columnName);
            Operations.Add(renameColumn);
            return renameColumn;
        }

        public IRenameTable Table(string tableName)
        {
            RenameTable renameTable = new RenameTable(tableName); 
            Operations.Add(renameTable);
            return renameTable;
        }
    }
}
