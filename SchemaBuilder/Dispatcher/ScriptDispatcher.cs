using SchemaBuilder.Core.Implementations.Script;
using SchemaBuilder.Translator.Implementations;
using SchemaBuilder.Translator.Interfaces.Base;
using System.Data.SqlClient;

namespace SchemaBuilder.Dispatcher
{
    public static class ScriptDispatcher
    {
        public static void Dispatch(SqlConnection connection, Script script)
        {
            ITranslator translator = TranslatorFactory.Create(script);

            connection.Open();
            SqlCommand command = new SqlCommand(translator.Translate(), connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
