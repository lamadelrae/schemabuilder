using Dapper;
using SchemaBuilder.Core.Implementations.Script;
using SchemaBuilder.Models;
using SchemaBuilder.Translator.Implementations;
using System.Data.SqlClient;

namespace SchemaBuilder.Dispatcher
{
    public class ScriptDispatcher
    {
        private readonly SqlConnection _connection;

        private readonly HistoryManager _historyManager;

        public ScriptDispatcher(SqlConnection connection)
        {
            _connection = connection;
            _historyManager = new HistoryManager(connection);
        }

        public void DispatchAll(IEnumerable<Script> scripts)
        {
            IEnumerable<int> scriptsRun = _historyManager.GetHistory().Select(x => x.ScriptId);
            IEnumerable<Script> scriptsNotRun = scripts.Where(x => !scriptsRun.Contains(x.Id));
            scriptsNotRun.ToList().ForEach(s => DispatchOne(s));
        }

        private void DispatchOne(Script script)
        {
            string sqlScript = TranslatorFactory.Create(script).Translate();
            _connection.Execute(sqlScript);
            _historyManager.InsertHistory(new History(Guid.NewGuid(), script.Id, sqlScript, DateTime.Now));
        }
    }
}
