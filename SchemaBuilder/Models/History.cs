namespace SchemaBuilder.Models
{
    public sealed class History
    {
        public Guid Id { get; private set; }

        public int ScriptId { get; private set; }

        public string Script { get; private set; }

        public DateTime DateCreated { get; private set; }

        public History(Guid id, int scriptId, string script, DateTime dateCreated)
        {
            Id = id;
            ScriptId = scriptId;
            Script = script;
            DateCreated = dateCreated;
        }
    }
}
