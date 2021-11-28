using SchemaBuilder.Models;

namespace SchemaBuilder.Core.Interfaces.Add
{
    public interface IAddContract
    {
        IAddColumnContract Column(string columnName, Func<Column, Column> func);

        IAddTableContract Table(string tableName);
    }
}