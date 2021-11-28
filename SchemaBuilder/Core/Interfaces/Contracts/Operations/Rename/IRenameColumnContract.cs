namespace SchemaBuilder.Core.Interfaces.Contracts.Operations.Rename
{
    public interface IRenameColumnContract
    {
        public IRenameColumnContract To(string columnName);

        public void In(string tableName);
    }
}
