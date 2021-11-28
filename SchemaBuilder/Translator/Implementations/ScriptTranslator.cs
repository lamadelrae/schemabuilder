using SchemaBuilder.Core;
using SchemaBuilder.Core.Interfaces.DataHolders.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaBuilder.Translator.Implementations
{
    public class ScriptTranslator
    {
        Script Script { get; set; }

        public List<string> Sqls { get; private set; } = new List<string>();

        public ScriptTranslator(Script script)
        {
            Script = script;
        }

        public void GenerateScript()
        {
            IEnumerable<IDataHolder> dataHolders = Script.Roots.SelectMany(l => l.Children);
            Sqls = dataHolders.Select(o => TranslatorFactory.Create(o).Translate()).ToList();
        }
    }
}
