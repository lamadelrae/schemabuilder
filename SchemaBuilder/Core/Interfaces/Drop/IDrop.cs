namespace SchemaBuilder.Core.Interfaces.Drop
{
    public interface IDrop
    {
        IDropColumn Column(string columnName);

        IDropTable Table(string tableName);
    }
}
