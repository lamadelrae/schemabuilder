using SchemaBuilder.Core.Interfaces.DataHolders.Base;

namespace SchemaBuilder.Core.Interfaces.DataHolders.Operations.Rename
{
    public interface IRenameColumnDataHolder : IDataHolder
    {
        public string FromColumn { get; }

        public string ToColumn { get; }

        public string TableName { get; }
    }
}
