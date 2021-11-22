namespace SchemaBuilder.Models
{
    public class Column
    {
        public Dictionary<ColumnProperties, object> Dictionary { get; private set; } = new Dictionary<ColumnProperties, object>();

        public ColumnTypes ColumnType { get; private set; }

        public Column Guid(bool primaryKey = false, bool foreignKey = false, bool nullable = false, Guid? defaultValue = null)
        {
            ColumnType = ColumnTypes.Guid;
            AddDefaultProperties(primaryKey, foreignKey, nullable, defaultValue);
            return this;
        }

        public Column Bool(bool primaryKey = false, bool foreignKey = false, bool nullable = false, bool? defaultValue = null)
        {
            ColumnType = ColumnTypes.Bool;
            AddDefaultProperties(primaryKey, foreignKey, nullable, defaultValue);
            return this;
        }

        public Column Int(bool primaryKey = false, bool foreignKey = false, bool nullable = false, int? defaultValue = null)
        {
            ColumnType = ColumnTypes.Int;
            AddDefaultProperties(primaryKey, foreignKey, nullable, defaultValue);
            return this;
        }

        public Column String(bool primaryKey = false, bool foreignKey = false, bool nullable = false, string defaultValue = null)
        {
            ColumnType = ColumnTypes.String;
            AddDefaultProperties(primaryKey, foreignKey, nullable, defaultValue);
            return this;
        }

        public Column Decimal(int precision, int scale, bool primaryKey = false, bool foreignKey = false, bool nullable = false, decimal? defaultValue = null)
        {
            ColumnType = ColumnTypes.String;
            AddDefaultProperties(primaryKey, foreignKey, nullable, defaultValue);
            Dictionary.Add(ColumnProperties.Precision, precision);
            Dictionary.Add(ColumnProperties.Scale, scale);
            return this;
        }

        private void AddDefaultProperties(bool primaryKey, bool foreignKey, bool nullable, object? defaultValue)
        {
            Dictionary.Add(ColumnProperties.PrimaryKey, primaryKey);
            Dictionary.Add(ColumnProperties.ForeignKey, foreignKey);
            Dictionary.Add(ColumnProperties.Nullable, nullable);
            Dictionary.Add(ColumnProperties.DefaultValue, defaultValue);
        }
    }
}
