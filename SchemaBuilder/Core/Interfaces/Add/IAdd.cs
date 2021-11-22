using SchemaBuilder.Models;

namespace SchemaBuilder.Core.Interfaces.Add
{
    public interface IAdd
    {
        IAddColumn Column(string columnName, Func<Column, Column> func);

        IAddTable Table(string tableName);
    }
}