using SchemaBuilder.Translator.Implementations;
using SchemaBuilder.UnitTests.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SchemaBuilder.UnitTests.TranslatorTests.Rename
{
    public class RenameTests
    {
        [Fact]
        public void ShouldRenameTable()
        {
            //Execution 
            string script = new ScriptTranslator(new RenameTableMock()).Translate();

            //Assertions
            Assert.NotNull(script);
            Assert.Equal("EXEC SP_RENAME 'Customer', 'Client';\n", script);
        }

        [Fact]
        public void ShouldRenameColumn()
        {
            //Execution 
            string script = new ScriptTranslator(new RenameColumnMock()).Translate();

            //Assertions
            Assert.NotNull(script);
            Assert.Equal("EXEC SP_RENAME 'Customer.Id', 'Ide', 'COLUMN';\n", script);
        }
    }
}
