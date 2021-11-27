using SchemaBuilder.Core.Interfaces.Rename;
using SchemaBuilder.SharedKernel;

namespace SchemaBuilder.Core.Implementations.Rename
{
    public class RenameColumn : IRenameColumn
    {
        public string FromColumn { get; set; } = string.Empty;

        public string ToColumn { get; set; } = string.Empty;

        public string TableName { get; set; } = string.Empty;

        public RenameColumn(string fromColumn)
        {
            FromColumn = fromColumn;
        }

        public IRenameColumn To(string columnName)
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

            ValidationException.ThrowIfFalse(isValid, "RenameColumn");
        }
    }
}
