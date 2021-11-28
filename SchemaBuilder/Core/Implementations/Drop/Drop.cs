using SchemaBuilder.Core.Interfaces.DataHolders.Base;
using SchemaBuilder.Core.Interfaces.DataHolders.Roots;
using SchemaBuilder.Core.Interfaces.Drop;
using SchemaBuilder.Core.Interfaces.Validations.Base;

namespace SchemaBuilder.Core.Implementations.Drop
{
    public class Drop : IDropContract, IRootDataHolder, IValidation
    {
        public List<IDataHolder> Children => new List<IDataHolder>();

        public IDropColumnConrtact Column(string columnName)
        {
            var dropColumn = new DropColumn(columnName);
            Children.Add(dropColumn);
            return dropColumn;
        }

        public IDropTableContract Table(string tableName)
        {
            var dropTable = new DropTable(tableName);
            Children.Add(dropTable);
            return dropTable;
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
