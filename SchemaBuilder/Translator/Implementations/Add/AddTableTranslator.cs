using SchemaBuilder.Core.Interfaces.DataHolders.Operations.Add;
using SchemaBuilder.Translator.Interfaces.Base;

namespace SchemaBuilder.Translator.Implementations.Add
{
    public class AddTableTranslator : ITranslator
    {
        private IAddTableDataHolder _dataHolder;

        public AddTableTranslator(IAddTableDataHolder dataHolder)
            => _dataHolder = dataHolder;

        public string Translate()
        {
            string sql = $"CRATE TABLE {_dataHolder.TableName}";
            sql += "(";
            sql += string.Join(", ", _dataHolder.Columns.Select((column) => $"{column.Key} {ColumnPropertyHelper.Create(column.Value)}"));
            sql += ")";
            return sql;
        }
    }
}
