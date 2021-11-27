using SchemaBuilder.Core.Interfaces.Base;
using SchemaBuilder.Core.Interfaces.Drop;
using SchemaBuilder.SharedKernel;

namespace SchemaBuilder.Core.Implementations.Drop
{
    public class DropTable : IDropTable, IValidation
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
