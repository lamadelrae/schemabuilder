using SchemaBuilder.Core.Interfaces.DataHolders.Base;

namespace SchemaBuilder.Core.Interfaces.DataHolders.Roots
{
    public interface IRootDataHolder : IDataHolder
    {
        public List<IDataHolder> Children { get; }
    }
}
