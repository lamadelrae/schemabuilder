using SchemaBuilder.Core.Interfaces.Contracts.Operations.Drop;

namespace SchemaBuilder.Core.Interfaces.Contracts.Roots.Drop
{
    public interface IDropContract
    {
        IDropColumnContract Column(string columnName);

        IDropTableContract Table(string tableName);
    }
}
