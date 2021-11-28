using SchemaBuilder.Core.Interfaces.DataHolders.Operations.Drop;
using SchemaBuilder.Translator.Interfaces.Base;

namespace SchemaBuilder.Translator.Implementations.Drop
{
    public class DropTableTranslator : ITranslator
    {
        private IDropTableDataHolder _dataHolder;

        public DropTableTranslator(IDropTableDataHolder dataHolder)
            => _dataHolder = dataHolder;

        public string Translate()
        {
            return $"DROP TABLE {_dataHolder.TableName}";
        }
    }
}
