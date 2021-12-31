using SchemaBuilder.Core.Interfaces.DataHolders.Operations.Drop;
using SchemaBuilder.Translator.Interfaces.Base;

namespace SchemaBuilder.Translator.Implementations.Drop
{
    public class DropColumnTranslator : ITranslator
    {
        private IDropColumnDataHolder _dataHolder;

        public DropColumnTranslator(IDropColumnDataHolder dataHolder)
            => _dataHolder = dataHolder;

        public string Translate()
        {
            return $"ALTER TABLE {_dataHolder.TableName} DROP COLUMN {_dataHolder.ColumnName}";
        }
    }
}
