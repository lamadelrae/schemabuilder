using SchemaBuilder.Core.Interfaces.DataHolders.Operations.Rename;
using SchemaBuilder.Translator.Interfaces.Base;

namespace SchemaBuilder.Translator.Implementations.Rename
{
    public class RenameTableTranslator : ITranslator
    {
        IRenameTableDataHolder _dataHolder;

        public RenameTableTranslator(IRenameTableDataHolder dataHolder)
            => _dataHolder = dataHolder;

        public string Translate()
        {
            return $"EXEC SP_RENAME '{_dataHolder.FromTable}', '{_dataHolder.ToTable}'";
        }
    }
}
