using SchemaBuilder.Core.Interfaces.Add;
using SchemaBuilder.Core.Interfaces.Base;
using SchemaBuilder.Models;

namespace SchemaBuilder.Core.Implementations.Add
{
    public class Add : IAdd
    {
        public List<IOperation> Operations => new List<IOperation>();

        public IAddColumn Column(string columnName, Func<Column, Column> func)
        {
            var addColumn = new AddColumn(columnName, func);
            Operations.Add(addColumn);
            return addColumn;
        }

        public IAddTable Table(string tableName)
        {
            var addTable = new AddTable(tableName);
            Operations.Add(addTable);
            return addTable;
        }
    }
}
