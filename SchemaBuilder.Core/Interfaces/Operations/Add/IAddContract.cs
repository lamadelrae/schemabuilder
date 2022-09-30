using SchemaBuilder.Core.Interfaces.Operations.Add.Column;
using SchemaBuilder.Core.Interfaces.Operations.Add.Table;
using SchemaBuilder.Core.Models;

namespace SchemaBuilder.Core.Interfaces.Operations.Add
{
    public interface IAddContract
    {
        IAddColumnContract Column(string columnName, Func<ColumnInformation, ColumnInformation> func);

        IAddTableContract Table(string tableName);
    }
}
