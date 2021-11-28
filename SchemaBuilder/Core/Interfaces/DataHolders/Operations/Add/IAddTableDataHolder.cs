using SchemaBuilder.Core.Interfaces.DataHolders.Base;
using SchemaBuilder.Models;

namespace SchemaBuilder.Core.Interfaces.DataHolders.Operations.Add
{
    public interface IAddTableDataHolder : IDataHolder
    {
        public string TableName { get; }

        public Dictionary<string, Column> Columns { get; }
    }
}
