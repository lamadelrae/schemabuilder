namespace SchemaBuilder.Core.Interfaces.Operations
{
    public interface IDataStore { }

    public interface IBaseDataStore : IDataStore
    {
        public Queue<IDataStore> Children { get; }
    }
}
