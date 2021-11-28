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
            Add().Table("SomeTable")
                 .Column("Id", x => x.Int())
                 .Column("Date", x => x.String());

            Drop().Table("Table");
        }
    }
}