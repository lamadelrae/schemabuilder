using SchemaBuilder.Core.Interfaces.Operations;

namespace SchemaBuilder.Core.Interfaces.Translators
{
    public interface IOperationTranslatorFactory
    {
        IOperationTranslator Create(IDataStore dataStore);
    }
}
