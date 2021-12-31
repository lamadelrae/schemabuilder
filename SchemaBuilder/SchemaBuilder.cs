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
            => new ScriptDispatcher(connection).DispatchAll(scripts.OrderBy(s => s.Id));

        /// <summary>
        /// /// Specify the connection and this method runs SchemaBuilder.
        /// </summary>
        /// <param name="connection"></param>
        public static void UseSchemaBuilder(SqlConnection connection)
        {
            ScriptDispatcher dispatcher = new ScriptDispatcher(connection);
            IEnumerable<Script> scripts = AppDomain.CurrentDomain
                .GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => x.BaseType == typeof(Script))
                .Select(x => (Script)Activator.CreateInstance(x)!)
                .OrderBy(s => s.Id);

            dispatcher.DispatchAll(scripts);
        }
    }
}