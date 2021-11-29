using SchemaBuilder.Core.Implementations.Script;
using SchemaBuilder.Core.Interfaces.Validations.Base;
using SchemaBuilder.Translator.Interfaces.Base;

namespace SchemaBuilder.Translator.Implementations
{
    public class ScriptTranslator : ITranslator
    {
        private readonly Script _script;

        public ScriptTranslator(Script script)
        {
            _script = script;
            Validate();
        }

        private void Validate()
        {
            _script.Roots
                .SelectMany(l => l.Children)
                .Select(d => d as IValidation)
                .Where(v => v != null).ToList()
                .ForEach(v => v!.IsValid());
        }

        public string Translate()
        {
            string script = string.Empty;
            _script.Roots.SelectMany(l => l.Children)
               .Select(o => TranslatorFactory.Create(o).Translate())
               .ToList().ForEach(x =>
               {
                   script += $"{x};\n";
               });

            return script;
        }
    }
}
