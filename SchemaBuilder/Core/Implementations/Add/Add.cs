using SchemaBuilder.Core.Interfaces.Add;
using SchemaBuilder.Core.Interfaces.Base;
using SchemaBuilder.Models;

namespace SchemaBuilder.Core.Implementations.Add
{
    public class Add : IAdd
    {
        public IAddColumn AddColumn { get; private set; }

        public IAddTable AddTable { get; private set; }

        public IAddColumn Column(string columnName, Func<Column, Column> func)
        {
            AddColumn = new AddColumn(columnName, func);
            return AddColumn;
        }

        public IAddTable Table(string tableName)
        {
            AddTable = new AddTable();
            return AddTable;
        }
    }
}
