using SchemaBuilder.Core.Implementations.Add;
using SchemaBuilder.Core.Implementations.Drop;
using SchemaBuilder.Core.Interfaces.Add;
using SchemaBuilder.Core.Interfaces.Drop;

namespace SchemaBuilder.Core
{
    public abstract class Script
    {
        protected int Id { get; private set; }

        public List<IAdd> Additions { get; private set; } = new List<IAdd>();

        public List<IDrop> Drops { get; private set; } = new List<IDrop>();

        public Script(int id)
        {
            Id = id;
        }

        public IAdd Add()
        {
            Add add = new Add();
            Additions.Add(add);
            return add;
        }

        public IDrop Drop()
        {
            Drop drop = new Drop();
            Drops.Add(drop);
            return drop;
        }
    }
}
