using SchemaBuilder.Core.Models;

namespace SchemaBuilder.Core.Interfaces.Operations.Add.Table
{
    public interface IAddTableDataStore : IDataStore
    {
        string TableName { get; }

        Dictionary<string, ColumnInformation> Columns { get; }
    }
}
