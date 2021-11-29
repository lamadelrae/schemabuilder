using SchemaBuilder.Core.Interfaces.DataHolders.Operations.Rename;
using SchemaBuilder.Translator.Interfaces.Base;

namespace SchemaBuilder.Translator.Implementations.Rename
{
    public class RenameColumnTranslator : ITranslator
    {
        IRenameColumnDataHolder _dataHolder;

        public RenameColumnTranslator(IRenameColumnDataHolder dataHolder)
            => _dataHolder = dataHolder;

        public string Translate()
        {
            return $"EXEC SP_RENAME '{_dataHolder.TableName}.{_dataHolder.FromColumn}', '{_dataHolder.ToColumn}', 'COLUMN'";
        }
    }
}
