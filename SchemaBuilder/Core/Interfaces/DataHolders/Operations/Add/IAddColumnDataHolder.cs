using SchemaBuilder.Core.Interfaces.DataHolders.Base;
using SchemaBuilder.Models;

namespace SchemaBuilder.Core.Interfaces.DataHolders.Operations.Add
{
    public interface IAddColumnDataHolder : IDataHolder
    {
        string ColumnName { get; }

        string TableName { get; }

        public Column Column { get; }
    }
}
