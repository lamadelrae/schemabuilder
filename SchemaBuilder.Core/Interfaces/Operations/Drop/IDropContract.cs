using SchemaBuilder.Core.Interfaces.Operations.Drop.Column;
using SchemaBuilder.Core.Interfaces.Operations.Drop.Table;

namespace SchemaBuilder.Core.Interfaces.Operations.Drop
{
    public interface IDropContract
    {
        IDropColumnContract Column(string columnName);

        IDropTableContract Table(string tableName);
    }
}
