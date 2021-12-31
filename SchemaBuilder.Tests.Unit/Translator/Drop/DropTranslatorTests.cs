using SchemaBuilder.Tests.SharedKernel;
using SchemaBuilder.Translator.Implementations;
using Xunit;

namespace SchemaBuilder.Tests.Unit.Translator.Drop
{
    public class DropTranslatorTests
    {
        [Fact]
        public void ShouldDropTable()
        {
            //Execution
            string script = new ScriptTranslator(new ScriptMockForUnit.DropTableMock()).Translate();

            //Assertions
            Assert.NotNull(script);
            Assert.Equal("DROP TABLE Customer;\n", script);
        }

        [Fact]
        public void ShouldDropColumn()
        {
            //Execution
            string script = new ScriptTranslator(new ScriptMockForUnit.DropColumnMock()).Translate();

            //Assertions
            Assert.NotNull(script);
            Assert.Equal("ALTER TABLE Customer DROP COLUMN Id;\n", script);
        }
    }
}
