using SchemaBuilder.Core.Interfaces.Contracts.Operations.Add;
using SchemaBuilder.Core.Interfaces.DataHolders.Operations.Add;
using SchemaBuilder.Core.Interfaces.Validations.Base;
using SchemaBuilder.Models;
using SchemaBuilder.SharedKernel;

namespace SchemaBuilder.Core.Implementations.Add
{
    public class AddTable : IAddTableContract, IAddTableDataHolder, IValidation
    {
        public string TableName { get; private set; }

        public Dictionary<string, Column> Columns { get; private set; } = new Dictionary<string, Column>();

        public AddTable(string tableName)
        {
            TableName = tableName;
        }

        public IAddTableContract Column(string columnName, Func<Column, Column> func)
        {
            Columns.Add(columnName, func(new Column()));
            return this;
        }

        public void IsValid()
        {
            bool isValid = new Validator<AddTable>(x => !string.IsNullOrEmpty(x.TableName) && x.Columns.Any())
                .Validate(this);

            ValidationException.ThrowIfFalse(isValid, "AddTable");
        }
    }
}
