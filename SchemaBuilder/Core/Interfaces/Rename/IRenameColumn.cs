using SchemaBuilder.Core.Interfaces.Base;

namespace SchemaBuilder.Core.Interfaces.Rename
{
    public interface IRenameColumn : IOperation
    {
        public IRenameColumn To(string columnName);

        public void In(string tableName);
    }
}
