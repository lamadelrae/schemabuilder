using SchemaBuilder.Core.Interfaces.Operations;
using SchemaBuilder.Core.Interfaces.Operations.Rename.Table;
using SchemaBuilder.Core.Shared;

namespace SchemaBuilder.Core.Operations.Rename.Table
{
    public class RenameTable : IRenameTableContract, IRenameTableDataStore, IValidation
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

            ValidationException.ThrowIfFalse(isValid, nameof(RenameTable));
        }
    }
}
