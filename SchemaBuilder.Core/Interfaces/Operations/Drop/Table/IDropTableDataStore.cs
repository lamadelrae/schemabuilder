namespace SchemaBuilder.Core.Interfaces.Operations.Drop.Column
{
    public interface IDropTableDataStore : IDataStore
    {
        string TableName { get; }
    }
}
