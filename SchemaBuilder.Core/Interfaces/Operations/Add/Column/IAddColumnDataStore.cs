using SchemaBuilder.Core.Models;

namespace SchemaBuilder.Core.Interfaces.Operations.Add.Column
{
    public interface IAddColumnDataStore : IDataStore
    {
        string ColumnName { get; }

        string TableName { get; }

        ColumnInformation ColumnInformation { get; }
    }
}
