using SchemaBuilder.Tests.SharedKernel;
using SchemaBuilder.Translator.Implementations;
using Xunit;

namespace SchemaBuilder.Tests.Unit.Translator.Add
{
    public class AddTranslatorTests
    {
        [Fact]
        public void ShouldCreateTable()
        {
            //Execution
            string script = new ScriptTranslator(new ScriptMockForUnit.CreateTablesMock()).Translate();

            //Assertions
            Assert.NotNull(script);
            Assert.Equal("CREATE TABLE Customer (Id INT PRIMARY KEY NOT NULL IDENTITY(1, 1), Name VARCHAR(120) NOT NULL);\n", script);
        }

        [Fact]
        public void ShouldCreateColumn()
        {
            //Execution
            string script = new ScriptTranslator(new ScriptMockForUnit.CreateColumnMock()).Translate();

            //Assertions
            Assert.NotNull(script);
            Assert.Equal("ALTER TABLE Customer ADD Email VARCHAR(120) NOT NULL;\n", script);
        }
    }
}
