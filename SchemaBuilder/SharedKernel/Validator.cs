using SchemaBuilder.Core.Interfaces.Base;

namespace SchemaBuilder.SharedKernel
{
    public class Validator<T>
    {
        Func<T, bool> Func { get; set; }

        public Validator(Func<T, bool> func)
        {
            Func = func;
        }

        public bool Validate(T operation)
        {
            return Func(operation);
        }
    }
}
