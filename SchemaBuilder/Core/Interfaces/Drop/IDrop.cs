using SchemaBuilder.Core.Interfaces.Base;

namespace SchemaBuilder.Core.Interfaces.Drop
{
    public interface IDrop : IRoot
    {
        IDropColumn Column(string columnName);

        IDropTable Table(string tableName);
    }
}
