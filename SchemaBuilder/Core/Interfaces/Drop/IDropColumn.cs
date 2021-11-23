using SchemaBuilder.Core.Interfaces.Base;

namespace SchemaBuilder.Core.Interfaces.Drop
{
    public interface IDropColumn : IOperation
    {
        public void In(string tableName);
    }
}
