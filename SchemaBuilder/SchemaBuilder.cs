using SchemaBuilder.Core.Implementations.Script;
using SchemaBuilder.Dispatcher;
using System.Data.SqlClient;

namespace SchemaBuilder
{
    public static class SchemaBuilder
    {
        /// <summary>
        /// Specify the connection and scripts, and this method runs SchemaBuilder.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="scripts"></param>
        public static void UseSchemaBuilder(SqlConnection connection, IEnumerable<Script> scripts)
            => new ScriptDispatcher(connection).DispatchAll(scripts);

        /// <summary>
        /// /// Specify the connection and this method runs SchemaBuilder.
        /// </summary>
        /// <param name="connection"></param>
        public static void UseSchemaBuilder(SqlConnection connection)
        {
            ScriptDispatcher dispatcher = new ScriptDispatcher(connection);
            List<Script> scripts = AppDomain.CurrentDomain
                .GetAssemblies().SelectMany(x => x.GetTypes())
                .OfType<Script>().ToList();

            dispatcher.DispatchAll(scripts);
        }
    }
}