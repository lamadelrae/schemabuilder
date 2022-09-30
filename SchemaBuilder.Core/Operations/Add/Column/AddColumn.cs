using SchemaBuilder.Core.Interfaces.Operations;
using SchemaBuilder.Core.Interfaces.Operations.Add.Column;
using SchemaBuilder.Core.Models;
using SchemaBuilder.Core.Shared;

namespace SchemaBuilder.Core.Operations.Add.Column
{
    public class AddColumn : IAddColumnContract, IAddColumnDataStore, IValidation
    {
        public string ColumnName { get; private set; } = string.Empty;

        public string TableName { get; private set; } = string.Empty;

        public ColumnInformation ColumnInformation { get; private set; }

        public AddColumn(string columnName, Func<ColumnInformation, ColumnInformation> func)
        {
            ColumnInformation = func(new ColumnInformation());
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
