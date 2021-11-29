using SchemaBuilder.Core.Implementations.Script;
using System.Collections.Generic;

namespace SchemaBuilder.UnitTests.SharedKernel
{
    public class ScriptMock
    {
        public List<Script> Scripts { get; set; } = new List<Script>();

        public ScriptMock()
        {
            Scripts.Add(new CreateTablesMock());
            Scripts.Add(new CreateColumnMock());
            Scripts.Add(new DropTableMock());
            Scripts.Add(new DropColumnMock());
        }
    }

    public class CreateTablesMock : Script
    {
        public CreateTablesMock() : base(id: 1)
        {
            Add().Table("Customer")
                .Column("Id", x => x.Int(primaryKey: true, func: x => x.Identity(1, 1)))
                .Column("Name", x => x.String(size: 120));
        }
    }

    public class CreateColumnMock : Script
    {
        public CreateColumnMock() : base(id: 2)
        {
            Add().Column("Email", x => x.String(120)).In("Customer");
        }
    }

    public class DropTableMock : Script
    {
        public DropTableMock() : base(id: 3)
        {
            Drop().Table("Customer");
        }
    }

    public class DropColumnMock : Script
    {
        public DropColumnMock() : base(id: 4)
        {
            Drop().Column("Id").In("Customer");
        }
    }

    public class RenameTableMock : Script
    {
        public RenameTableMock() : base(id: 5)
        {
            Rename().Table("Customer").To("Client");
        }
    }

    public class RenameColumnMock : Script
    {
        public RenameColumnMock() : base(id: 6)
        {
            Rename().Column("Id").To("Ide").In("Customer");
        }
    }
}
