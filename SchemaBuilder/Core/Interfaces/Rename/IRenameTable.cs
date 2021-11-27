using SchemaBuilder.Core.Interfaces.Base;

namespace SchemaBuilder.Core.Interfaces.Rename
{
    public interface IRenameTable : IOperation
    {
        public void To(string tableName);
    }
}
