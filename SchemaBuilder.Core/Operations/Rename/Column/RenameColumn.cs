using SchemaBuilder.Core.Interfaces.Operations;
using SchemaBuilder.Core.Interfaces.Operations.Rename.Column;
using SchemaBuilder.Core.Shared;

namespace SchemaBuilder.Core.Operations.Rename.Column
{
    public class RenameColumn : IRenameColumnContract, IRenameColumnDataStore, IValidation
    {
        public string FromColumn { get; private set; } = string.Empty;

        public string ToColumn { get; private set; } = string.Empty;

        public string TableName { get; private set; } = string.Empty;

        public RenameColumn(string fromColumn)
        {
            FromColumn = fromColumn;
        }

        public IRenameColumnContract To(string columnName)
        {
            ToColumn = columnName;
            return this;
        }

        public void In(string tableName)
        {
            TableName = tableName;
        }

        public void IsValid()
        {
            bool isValid = new Validator<RenameColumn>(x => !string.IsNullOrEmpty(x.FromColumn) && !string.IsNullOrEmpty(x.ToColumn) && !string.IsNullOrEmpty(x.TableName))
                .Validate(this);

            ValidationException.ThrowIfFalse(isValid, nameof(RenameColumn));
        }
    }
}