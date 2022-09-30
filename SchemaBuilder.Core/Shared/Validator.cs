namespace SchemaBuilder.Core.Shared
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
