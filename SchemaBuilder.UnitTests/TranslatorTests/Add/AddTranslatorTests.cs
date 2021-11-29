using SchemaBuilder.Translator.Implementations;
using SchemaBuilder.UnitTests.SharedKernel;
using Xunit;

namespace SchemaBuilder.UnitTests.TranslatorTests.Add
{
    public class AddTranslatorTests
    {
        [Fact]
        public void ShouldCreateTable()
        {
            //Execution
            string script = new ScriptTranslator(new CreateTablesMock()).Translate();

            //Assertions
            Assert.NotNull(script);
            Assert.Equal("CREATE TABLE Customer(Id INT PRIMARY KEY NOT NULL IDENTITY(1, 1), Name VARCHAR(120) NOT NULL);\n", script);
        }

        [Fact]
        public void ShouldCreateColumn()
        {
            //Execution
            string script = new ScriptTranslator(new CreateColumnMock()).Translate();

            //Assertions
            Assert.NotNull(script);
            Assert.Equal("ALTER TABLE Customer ADD Email VARCHAR(120) NOT NULL;\n", script);
        }
    }
}
