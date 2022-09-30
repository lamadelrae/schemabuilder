using SchemaBuilder.Core.Interfaces.Operations;
using SchemaBuilder.Core.Interfaces.Operations.Add;
using SchemaBuilder.Core.Interfaces.Operations.Add.Column;
using SchemaBuilder.Core.Interfaces.Operations.Add.Table;
using SchemaBuilder.Core.Models;
using SchemaBuilder.Core.Operations.Add.Column;
using SchemaBuilder.Core.Operations.Add.Table;

namespace SchemaBuilder.Core.Operations.Add
{
    public class Add : IAddContract, IBaseDataStore
    {
        public Queue<IDataStore> Children { get; } = new Queue<IDataStore>();

        public IAddColumnContract Column(string columnName, Func<ColumnInformation, ColumnInformation> func)
        {
            var addColumn = new AddColumn(columnName, func);
            Children.Enqueue(addColumn);
            return addColumn;
        }

        public IAddTableContract Table(string tableName)
        {
            var addTable = new AddTable(tableName);
            Children.Enqueue(addTable);
            return addTable;
        }
    }
}
