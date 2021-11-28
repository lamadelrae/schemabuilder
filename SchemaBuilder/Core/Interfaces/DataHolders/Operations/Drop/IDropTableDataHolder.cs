using SchemaBuilder.Core.Interfaces.DataHolders.Base;

namespace SchemaBuilder.Core.Interfaces.DataHolders.Operations.Drop
{
    public interface IDropTableDataHolder : IDataHolder
    {
        public string TableName { get; }
    }
}
