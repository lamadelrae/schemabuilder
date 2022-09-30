namespace SchemaBuilder.Core.Interfaces.Operations.Rename.Table
{
    public interface IRenameTableDataStore : IDataStore
    {
        string FromTable { get; }

        string ToTable { get; }
    }
}
