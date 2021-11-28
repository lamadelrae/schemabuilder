using SchemaBuilder.Core.Interfaces.DataHolders.Base;

namespace SchemaBuilder.Core.Interfaces.DataHolders.Operations.Rename
{
    public interface IRenameTableDataHolder : IDataHolder
    {
        public string FromTable { get; }

        public string ToTable { get; }
    }
}
