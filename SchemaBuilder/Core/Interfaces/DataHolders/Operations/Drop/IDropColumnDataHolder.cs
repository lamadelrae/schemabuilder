using SchemaBuilder.Core.Interfaces.DataHolders.Base;

namespace SchemaBuilder.Core.Interfaces.DataHolders.Operations.Drop
{
    public interface IDropColumnDataHolder : IDataHolder
    {
        public string ColumnName { get; }

        public string TableName { get; }
    }
}
