using SchemaBuilder.Core.Implementations.Script;
using SchemaBuilder.Dispatcher;
using System.Data.SqlClient;

namespace SchemaBuilder.IoC
{
    public static class SchemaBuilder
    {
        /// <summary>
        /// Specify the connection and scripts, and this method runs SchemaBuilder.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="scripts"></param>
        public static void UseSchemaBuilder(SqlConnection connection, IEnumerable<Script> scripts)
            => scripts.ToList().ForEach(script => ScriptDispatcher.Dispatch(connection, script));

        /// <summary>
        /// /// Specify the connection and this method runs SchemaBuilder.
        /// </summary>
        /// <param name="connection"></param>
        public static void UseSchemaBuilder(SqlConnection connection)
        {
            List<Script> scripts = AppDomain.CurrentDomain
                .GetAssemblies().SelectMany(x => x.GetTypes())
                .OfType<Script>().ToList();

            scripts.ForEach(script => ScriptDispatcher.Dispatch(connection, script));
        }
    }
}