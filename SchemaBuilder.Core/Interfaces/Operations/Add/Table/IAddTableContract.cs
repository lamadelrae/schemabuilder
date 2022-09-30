using SchemaBuilder.Core.Models;

namespace SchemaBuilder.Core.Interfaces.Operations.Add.Table
{
    public interface IAddTableContract
    {
        IAddTableContract WithColumn(string columnName, Func<ColumnInformation, ColumnInformation> func);
    }
}
