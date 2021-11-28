using SchemaBuilder.Core.Interfaces.Add;
using SchemaBuilder.Core.Interfaces.DataHolders.Operations.Add;
using SchemaBuilder.Core.Interfaces.Validations.Base;
using SchemaBuilder.Models;
using SchemaBuilder.SharedKernel;

namespace SchemaBuilder.Core.Implementations.Add
{
    public class AddColumn : IAddColumnContract, IAddColumnDataHolder, IValidation
    {
        public string ColumnName { get; private set; } = string.Empty;

        public string TableName { get; private set; } = string.Empty;

        public Column Column { get; private set; }

        public AddColumn(string columnName, Func<Column, Column> func)
        {
            Column = func(new Column());
            ColumnName = columnName;
        }

        public void In(string tableName)
        {
            TableName = tableName;
        }

        public void IsValid()
        {
            bool isValid = new Validator<AddColumn>(x => !string.IsNullOrEmpty(x.ColumnName) && !string.IsNullOrEmpty(x.TableName) && x.ColumnName != null)
                .Validate(this);

            ValidationException.ThrowIfFalse(isValid, "AddColumn");
        }
    }
}
