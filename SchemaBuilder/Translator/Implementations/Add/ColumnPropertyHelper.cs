using SchemaBuilder.Models;

namespace SchemaBuilder.Translator.Implementations.Add
{
    public static class ColumnPropertyHelper
    {
        public static string Create(Column columnInfo)
        {
            var properties = columnInfo.Properties;
            string column = string.Empty;
            column += GetColumnType(columnInfo);

            if ((bool)properties[ColumnProperty.PrimaryKey])
                column += "PRIMARY KEY";
            if (!(bool)properties[ColumnProperty.Nullable])
                column += "NOT NULL";
            if ((bool)properties[ColumnProperty.Identity])
            {
                int start = (int)properties[ColumnProperty.IdentityStart];
                int increment = (int)properties[ColumnProperty.IdentityIncrement];
                column += $"IDENTITY({start}, {increment})";
            }

            return column;
        }

        private static string GetColumnType(Column columnInfo)
        {
            var properties = columnInfo.Properties;
            return columnInfo.ColumnType switch
            {
                ColumnType.String => $"VARCHAR({properties[ColumnProperty.Size]})",
                ColumnType.Decimal => $"DECIMAL({properties[ColumnProperty.Scale]}, {properties[ColumnProperty.Precision]})",
                ColumnType.Bool => $"BIT",
                ColumnType.Guid => "UNIQUEIDENTIFIER",
                ColumnType.DateTime => "DATETIME",
                ColumnType.Int => "INT",
                _ => throw new Exception("Type not supported.")
            };
        }
    }
}
