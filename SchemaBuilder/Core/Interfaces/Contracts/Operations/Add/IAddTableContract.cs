using SchemaBuilder.Models;

namespace SchemaBuilder.Core.Interfaces.Contracts.Operations.Add
{
    public interface IAddTableContract
    {
        IAddTableContract Column(string columnName, Func<ColumnInfo, ColumnInfo> func);
    }
}
