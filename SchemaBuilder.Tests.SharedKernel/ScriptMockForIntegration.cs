using SchemaBuilder.Core.Implementations.Script;

namespace SchemaBuilder.Tests.SharedKernel
{
    public class ScriptMockForIntegration
    {
        public class CreateTables : Script
        {
            public CreateTables() : base(1)
            {
                Add().Table("Customer")
                    .Column("Id", p => p.Guid(primaryKey: true))
                    .Column("Name", p => p.String(120))
                    .Column("BirthDate", p => p.DateTime());

                Add().Table("Company")
                    .Column("Id", p => p.Guid(primaryKey: true))
                    .Column("Name", p => p.String(120))
                    .Column("FoundationDate", p => p.DateTime());
            }
        }

        public class CreateColumns : Script
        {
            public CreateColumns() : base(2)
            {
                Add().Column("FatherName", p => p.String(120))
                    .In("Customer");

                Add().Column("OwnerName", p => p.String(120))
                    .In("Company");
            }
        }

        public class RenameColumns : Script
        {
            public RenameColumns() : base(3)
            {
                Rename().Column("FatherName")
                    .To("Father").In("Customer");

                Rename().Column("OwnerName")
                    .To("Owner").In("Company");
            }
        }

        public class DropColumns : Script
        {
            public DropColumns() : base(4)
            {
                Drop().Column("Father").In("Customer");
                Drop().Column("Owner").In("Company");
            }
        }

        public class DropTables : Script
        {
            public DropTables() : base(5)
            {
                Drop().Table("Customer");
                Drop().Table("Company");
            }
        }
    }
}