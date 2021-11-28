namespace SchemaBuilder.Core.Interfaces.Rename
{
    public interface IRenameColumnContract
    {
        public IRenameColumnContract To(string columnName);

        public void In(string tableName);
    }
}
