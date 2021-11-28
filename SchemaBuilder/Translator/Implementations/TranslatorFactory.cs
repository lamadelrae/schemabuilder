using SchemaBuilder.Core.Implementations.Script;
using SchemaBuilder.Core.Interfaces.DataHolders.Base;
using SchemaBuilder.Core.Interfaces.DataHolders.Operations.Add;
using SchemaBuilder.Core.Interfaces.DataHolders.Operations.Drop;
using SchemaBuilder.Core.Interfaces.DataHolders.Operations.Rename;
using SchemaBuilder.Translator.Implementations.Add;
using SchemaBuilder.Translator.Implementations.Drop;
using SchemaBuilder.Translator.Implementations.Rename;
using SchemaBuilder.Translator.Interfaces.Base;

namespace SchemaBuilder.Translator.Implementations
{
    public static class TranslatorFactory
    {
        public static ITranslator Create(Script script)
            => new ScriptTranslator(script);

        public static ITranslator Create(IDataHolder dataHolder)
        {
            return dataHolder switch
            {
                IAddColumnDataHolder => new AddColumnTranslator((IAddColumnDataHolder)dataHolder),
                IAddTableDataHolder => new AddTableTranslator((IAddTableDataHolder)dataHolder),
                IDropTableDataHolder => new DropTableTranslator((IDropTableDataHolder)dataHolder),
                IDropColumnDataHolder => new DropColumnTranslator((IDropColumnDataHolder)dataHolder),
                IRenameColumnDataHolder => new RenameColumnTranslator((IRenameColumnDataHolder)dataHolder),
                IRenameTableDataHolder => new RenameTableTranslator((IRenameTableDataHolder)dataHolder),
                _ => throw new NotSupportedException("Data Holder not supported.")
            };
        }
    }
}
