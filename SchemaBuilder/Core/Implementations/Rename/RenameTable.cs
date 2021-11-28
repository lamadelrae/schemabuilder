using SchemaBuilder.Core.Interfaces.DataHolders.Operations.Rename;
using SchemaBuilder.Core.Interfaces.Rename;
using SchemaBuilder.Core.Interfaces.Validations.Base;
using SchemaBuilder.SharedKernel;

namespace SchemaBuilder.Core.Implementations.Rename
{
    public class RenameTable : IRenameTableContract, IRenameTableDataHolder, IValidation
    {
        public string FromTable { get; private set; } = string.Empty;

        public string ToTable { get; private set; } = string.Empty;

        public RenameTable(string fromTable)
        {
            FromTable = fromTable;
        }

        public void To(string toTable)
        {
            ToTable = toTable;
        }

        public void IsValid()
        {
            bool isValid = new Validator<RenameTable>(x => !string.IsNullOrEmpty(x.FromTable) && !string.IsNullOrEmpty(x.ToTable))
                .Validate(this);

            ValidationException.ThrowIfFalse(isValid, "RenameTable");
        }
    }
}
