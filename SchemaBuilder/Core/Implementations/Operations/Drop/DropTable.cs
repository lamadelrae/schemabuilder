using SchemaBuilder.Core.Interfaces.Contracts.Operations.Drop;
using SchemaBuilder.Core.Interfaces.DataHolders.Operations.Drop;
using SchemaBuilder.Core.Interfaces.Validations.Base;
using SchemaBuilder.SharedKernel;

namespace SchemaBuilder.Core.Implementations.Operations.Drop
{
    public class DropTable : IDropTableContract, IDropTableDataHolder, IValidation
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
