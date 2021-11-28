namespace SchemaBuilder.Core.Interfaces.Drop
{
    public interface IDropContract
    {
        IDropColumnConrtact Column(string columnName);

        IDropTableContract Table(string tableName);
    }
}
