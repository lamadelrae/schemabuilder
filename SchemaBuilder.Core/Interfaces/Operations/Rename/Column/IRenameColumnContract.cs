namespace SchemaBuilder.Core.Interfaces.Operations.Rename.Column
{
    public interface IRenameColumnContract
    {
        IRenameColumnContract To(string columnName);

        public void In(string tableName);
    }
}
