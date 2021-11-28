using SchemaBuilder.Core.Interfaces.DataHolders.Base;
using SchemaBuilder.Core.Interfaces.DataHolders.Roots;
using SchemaBuilder.Core.Interfaces.Rename;
using SchemaBuilder.Core.Interfaces.Validations.Base;

namespace SchemaBuilder.Core.Implementations.Rename
{
    public class Rename : IRenameContract, IRootDataHolder, IValidation
    {
        public List<IDataHolder> Children => new List<IDataHolder>();

        public IRenameColumnContract Column(string columnName)
        {
            RenameColumn renameColumn = new RenameColumn(columnName);
            Children.Add(renameColumn);
            return renameColumn;
        }


        public IRenameTableContract Table(string tableName)
        {
            RenameTable renameTable = new RenameTable(tableName);
            Children.Add(renameTable);
            return renameTable;
        }

        public void IsValid()
        {
            Children.Select(c => c as IValidation)
                .Where(v => v is not null)
                .ToList()
                .ForEach(v => v!.IsValid());
        }
    }
}
