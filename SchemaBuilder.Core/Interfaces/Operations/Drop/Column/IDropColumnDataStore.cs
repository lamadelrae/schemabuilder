namespace SchemaBuilder.Core.Interfaces.Operations.Drop.Column
{
    public interface IDropColumnDataStore : IDataStore
    {
        string ColumnName { get; }

        string TableName { get; }
    }
}
