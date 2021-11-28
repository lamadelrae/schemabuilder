using SchemaBuilder.Core.Interfaces.DataHolders.Operations.Add;
using SchemaBuilder.Translator.Interfaces.Base;

namespace SchemaBuilder.Translator.Implementations.Add
{
    public class AddColumnTranslator : ITranslator
    {
        private IAddColumnDataHolder _dataHolder;

        public AddColumnTranslator(IAddColumnDataHolder dataHolder)
        {
            _dataHolder = dataHolder;
        }

        public string Translate()
        {
            return "";
        }
    }
}
