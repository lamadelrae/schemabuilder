using SchemaBuilder.Core.Interfaces.Base;
using SchemaBuilder.Models;

namespace SchemaBuilder.Core.Interfaces.Add
{
    public interface IAdd : IRoot
    {
        IAddColumn Column(string columnName, Func<Column, Column> func);

        IAddTable Table(string tableName);
    }
}