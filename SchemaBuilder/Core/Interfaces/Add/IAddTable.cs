using SchemaBuilder.Core.Interfaces.Base;
using SchemaBuilder.Models;

namespace SchemaBuilder.Core.Interfaces.Add
{
    public interface IAddTable : IOperation
    {
        IAddTable Column(string columnName, Func<Column, Column> func);
    }
}
