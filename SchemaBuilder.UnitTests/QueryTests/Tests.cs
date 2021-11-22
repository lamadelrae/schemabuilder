using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchemaBuilder.Core;

namespace SchemaBuilder.UnitTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestMethod1() { }
    }

    public class SomeScript : Script
    {
        public SomeScript() : base(id: 1)
        {
            Add().Column("Name", x => x.String())
                .In("TableName");

            Add().Table("TableName")
                 .Column("ColumnName", x => x.Guid())
                 .Column("ColumnName", x => x.Int());

            Drop().Table("TableName");
            Drop().Column("ColumnName").In("TableName");
        }
    }
}