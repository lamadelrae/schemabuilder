using SchemaBuilder.Core.Interfaces.Base;

namespace SchemaBuilder.Core.Interfaces.Rename
{
    public interface IRename : IRoot
    {
        public IRenameTable Table(string tableName);

        public IRenameColumn Column(string columnName);
    }
}
