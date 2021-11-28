using SchemaBuilder.Models;

namespace SchemaBuilder.Core.Interfaces.Add
{
    public interface IAddTableContract
    {
        IAddTableContract Column(string columnName, Func<Column, Column> func);
    }
}
