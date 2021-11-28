using SchemaBuilder.Core.Implementations.Operations.Add;
using SchemaBuilder.Core.Interfaces.Contracts.Operations.Add;
using SchemaBuilder.Core.Interfaces.Contracts.Roots.Add;
using SchemaBuilder.Core.Interfaces.DataHolders.Base;
using SchemaBuilder.Core.Interfaces.DataHolders.Roots;
using SchemaBuilder.Models;

namespace SchemaBuilder.Core.Implementations.Roots.Add
{
    public class Add : IAddContract, IRootDataHolder
    {
        public List<IDataHolder> Children => new List<IDataHolder>();

        public IAddColumnContract Column(string columnName, Func<Column, Column> func)
        {
            var addColumn = new AddColumn(columnName, func);
            Children.Add(addColumn);
            return addColumn;
        }

        public IAddTableContract Table(string tableName)
        {
            var addTable = new AddTable(tableName);
            Children.Add(addTable);
            return addTable;
        }
    }
}
