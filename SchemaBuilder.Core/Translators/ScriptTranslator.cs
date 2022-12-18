using SchemaBuilder.Core.Interfaces.Operations;
using SchemaBuilder.Core.Interfaces.Translators;
using SchemaBuilder.Core.Operations;

namespace SchemaBuilder.Core.Translators
{
    public class ScriptTranslator
    {
        private readonly IOperationTranslatorFactory _translatorFactory;

        public ScriptTranslator(IOperationTranslatorFactory translatorFactory)
            => _translatorFactory = translatorFactory;

        private static void Validate(Script script)
        {
            script.Roots
                .SelectMany(l => l.Children)
                .Select(d => d as IValidation)
                .Where(v => v != null).ToList()
                .ForEach(v => v!.IsValid());
        }

        public string Execute(Script script)
        {
            Validate(script);

            return script.Roots.SelectMany(l => l.Children)
               .Select(o => _translatorFactory.Create(o).Execute())
               .Aggregate((script, operation) => $"{script}{operation};\n");
        }
    }
}
