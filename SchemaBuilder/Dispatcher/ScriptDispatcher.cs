using SchemaBuilder.Core.Implementations.Script;
using SchemaBuilder.Translator.Implementations;
using SchemaBuilder.Translator.Interfaces.Base;
using System.Data.SqlClient;

namespace SchemaBuilder.Dispatcher
{
    public class ScriptDispatcher
    {
        SqlConnection _connection;

        ITranslator _translator;

        public ScriptDispatcher(SqlConnection connection, Script script)
        {
            _connection = connection;
            _translator = TranslatorFactory.Create(script);
        }

        public void Dispatch()
        {
            using (var connection = _connection)
            {
                SqlCommand command = new SqlCommand(_translator.Translate(), connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
