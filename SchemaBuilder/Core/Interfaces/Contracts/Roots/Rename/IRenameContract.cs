namespace SchemaBuilder.Core.Interfaces.Rename
{
    public interface IRenameContract
    {
        public IRenameTableContract Table(string tableName);

        public IRenameColumnContract Column(string columnName);
    }
}
