namespace SchemaBuilder.Models
{
    public class Column
    {
        public Dictionary<ColumnProperty, object> Properties { get; private set; } = new Dictionary<ColumnProperty, object>();

        public ColumnType ColumnType { get; private set; }

        public Column Guid(bool primaryKey = false, bool foreignKey = false, bool nullable = false, Guid? defaultValue = null)
        {
            ColumnType = ColumnType.Guid;
            AddDefaultProperties(primaryKey, foreignKey, nullable, defaultValue);
            return this;
        }

        public Column Bool(bool primaryKey = false, bool foreignKey = false, bool nullable = false, bool? defaultValue = null)
        {
            ColumnType = ColumnType.Bool;
            AddDefaultProperties(primaryKey, foreignKey, nullable, defaultValue);
            return this;
        }

        public Column Int(Func<ColumnIdentity, ColumnIdentity>? func = null, bool primaryKey = false, bool foreignKey = false, bool nullable = false, int? defaultValue = null)
        {
            ColumnType = ColumnType.Int;
            AddDefaultProperties(primaryKey, foreignKey, nullable, defaultValue);
            if(func != null)
            {
                ColumnIdentity identity = func(new ColumnIdentity());
                Properties.Add(ColumnProperty.Identity, true);
                Properties.Add(ColumnProperty.IdentityStart, identity.Start);
                Properties.Add(ColumnProperty.IdentityIncrement, identity.Increment);
            }
            return this;
        }

        public Column String(string size, bool primaryKey = false, bool foreignKey = false, bool nullable = false, string? defaultValue = null)
        {
            ColumnType = ColumnType.String;
            AddDefaultProperties(primaryKey, foreignKey, nullable, defaultValue);
            Properties.Add(ColumnProperty.Size, size);
            return this;
        }

        public Column Decimal(int precision, int scale, bool primaryKey = false, bool foreignKey = false, bool nullable = false, decimal? defaultValue = null)
        {
            ColumnType = ColumnType.String;
            AddDefaultProperties(primaryKey, foreignKey, nullable, defaultValue);
            Properties.Add(ColumnProperty.Precision, precision);
            Properties.Add(ColumnProperty.Scale, scale);
            return this;
        }

        public Column DateTime(bool primaryKey = false, bool foreignKey = false, bool nullable = false, DateTime? defaultValue = null)
        {
            ColumnType = ColumnType.DateTime;
            AddDefaultProperties(primaryKey, foreignKey, nullable, defaultValue);
            return this;
        }

        private void AddDefaultProperties(bool primaryKey, bool foreignKey, bool nullable, object? defaultValue)
        {
            Properties.Add(ColumnProperty.PrimaryKey, primaryKey);
            Properties.Add(ColumnProperty.ForeignKey, foreignKey);
            Properties.Add(ColumnProperty.Nullable, nullable);
            Properties.Add(ColumnProperty.DefaultValue, defaultValue ?? new { });
        }

        public class ColumnIdentity
        {
            public int Start { get; private set; } = 0;

            public int Increment { get; private set; } = 0;

            public ColumnIdentity Identity(int start, int increment)
            {
                Start = start;
                Increment = increment;
                return this;
            }
        }
    }
}
