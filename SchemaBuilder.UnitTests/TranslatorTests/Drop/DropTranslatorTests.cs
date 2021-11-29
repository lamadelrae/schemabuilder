using SchemaBuilder.Translator.Implementations;
using SchemaBuilder.UnitTests.SharedKernel;
using Xunit;

namespace SchemaBuilder.UnitTests.TranslatorTests.Drop
{
    public class DropTranslatorTests
    {
        [Fact]
        public void ShouldDropTable()
        {
            //Execution
            string script = new ScriptTranslator(new DropTableMock()).Translate();

            //Assertions
            Assert.NotNull(script);
            Assert.Equal("DROP TABLE Customer;\n", script);
        }

        [Fact]
        public void ShouldDropColumn()
        {
            //Execution
            string script = new ScriptTranslator(new DropColumnMock()).Translate();

            //Assertions
            Assert.NotNull(script);
            Assert.Equal("ALTER TABLE Customer DROP Id;\n", script);
        }
    }
}
