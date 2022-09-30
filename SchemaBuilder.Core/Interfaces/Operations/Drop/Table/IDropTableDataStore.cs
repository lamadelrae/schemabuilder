namespace SchemaBuilder.Core.Interfaces.Operations.Drop.Table
{
    public interface IDropTableDataStore : IDataStore
    {
        string TableName { get; }
    }
}
