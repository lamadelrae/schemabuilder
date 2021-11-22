using SchemaBuilder.Models;

namespace SchemaBuilder.Core.Interfaces.Add
{
    public interface IAddTable
    {
        IAddTable Column(string columnName, Func<Column, Column> func);
    }
}
