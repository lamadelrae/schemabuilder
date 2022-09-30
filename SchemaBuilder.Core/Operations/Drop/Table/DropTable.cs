using SchemaBuilder.Core.Interfaces.Operations;
using SchemaBuilder.Core.Interfaces.Operations.Drop.Column;
using SchemaBuilder.Core.Shared;

namespace SchemaBuilder.Core.Operations.Drop.Table
{
    public class DropTable : IDropTableContract, IDropTableDataStore, IValidation
    {
        public string TableName { get; private set; }

        public DropTable(string tableName)
        {
            TableName = tableName;
        }

        public void IsValid()
        {
            bool isValid = new Validator<DropTable>(x => !string.IsNullOrEmpty(x.TableName))
                .Validate(this);

            ValidationException.ThrowIfFalse(isValid, "DropTable");
        }
    }
}
