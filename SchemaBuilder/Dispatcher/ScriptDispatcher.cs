using SchemaBuilder.Core.Implementations.Script;
using SchemaBuilder.Models;
using SchemaBuilder.Translator.Implementations;
using System.Data.SqlClient;

namespace SchemaBuilder.Dispatcher
{
    public class ScriptDispatcher
    {
        SqlConnection _connection;

        private HistoryManager _historyManager;

        public ScriptDispatcher(SqlConnection connection)
        {
            _connection = connection;
            _historyManager = new HistoryManager(connection);
        }

        public void DispatchAll(IEnumerable<Script> scripts)
        {
            IEnumerable<History> histories = _historyManager.GetHistory();
            IEnumerable<Script> scriptsNotRun = scripts.Where(s => !histories.Any(h => h.ScriptId == s.Id));
            scriptsNotRun.ToList().ForEach(s => DispatchOne(s));
        }

        private void DispatchOne(Script script)
        {
            string sqlScript = TranslatorFactory.Create(script).Translate();
            _connection.Open();
            SqlCommand command = new SqlCommand(sqlScript, _connection);
            command.ExecuteNonQuery();
            _connection.Close();

            _historyManager.InsertHistory(new History(Guid.NewGuid(), script.Id, sqlScript, DateTime.Now));
        }
    }
}
