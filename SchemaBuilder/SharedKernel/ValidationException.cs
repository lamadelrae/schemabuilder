namespace SchemaBuilder.SharedKernel
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }

        public static void ThrowIfFalse(bool input, string context)
        {
            if (!input)
                throw new ValidationException($"The {context} context is not valid.");
        }
    }
}
