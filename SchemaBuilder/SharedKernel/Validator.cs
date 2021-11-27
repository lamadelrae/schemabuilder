using SchemaBuilder.Core.Interfaces.Base;

namespace SchemaBuilder.SharedKernel
{
    public class Validator<TOperation> where TOperation : IOperation
    {
        Func<TOperation, bool> Func { get; set; }

        public Validator(Func<TOperation, bool> func)
        {
            Func = func;
        }

        public bool Validate(TOperation operation)
        {
            return Func(operation);
        }
    }
}
