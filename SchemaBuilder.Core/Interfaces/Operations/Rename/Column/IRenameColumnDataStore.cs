namespace SchemaBuilder.Core.Interfaces.Operations.Rename.Column
{
    public interface IRenameColumnDataStore : IDataStore
    {
        string FromColumn { get; }

        string ToColumn { get; }

        string TableName { get; }
    }
}
