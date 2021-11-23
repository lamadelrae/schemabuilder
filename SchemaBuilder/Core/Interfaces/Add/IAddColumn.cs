using SchemaBuilder.Core.Interfaces.Base;

namespace SchemaBuilder.Core.Interfaces.Add
{
    public interface IAddColumn : IOperation
    {
        void In(string tableName);
    }
}
