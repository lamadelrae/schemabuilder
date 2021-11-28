using SchemaBuilder.Core.Interfaces.Add;
using SchemaBuilder.Core.Interfaces.DataHolders.Base;
using SchemaBuilder.Core.Interfaces.DataHolders.Roots;
using SchemaBuilder.Core.Interfaces.Validations.Base;
using SchemaBuilder.Models;

namespace SchemaBuilder.Core.Implementations.Add
{
    public class Add : IAddContract, IRootDataHolder, IValidation
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

        public void IsValid()
        {
            Children.Select(c => c as IValidation)
                .Where(v => v is not null)
                .ToList()
                .ForEach(v => v!.IsValid());
        }
    }
}
