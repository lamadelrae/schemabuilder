using SchemaBuilder.Core.Interfaces.Operations;
using SchemaBuilder.Core.Interfaces.Operations.Add.Table;
using SchemaBuilder.Core.Models;
using SchemaBuilder.Core.Shared;

namespace SchemaBuilder.Core.Operations.Add.Table
{
    public class AddTable : IAddTableContract, IAddTableDataStore, IValidation
    {
        public string TableName { get; private set; }

        public Dictionary<string, ColumnInformation> Columns { get; private set; } = new Dictionary<string, ColumnInformation>();

        public AddTable(string tableName)
        {
            TableName = tableName;
        }

        public IAddTableContract WithColumn(string columnName, Func<ColumnInformation, ColumnInformation> func)
        {
            Columns.Add(columnName, func(new ColumnInformation()));
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
