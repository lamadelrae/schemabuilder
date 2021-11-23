using SchemaBuilder.Core.Implementations.Add;
using SchemaBuilder.Core.Implementations.Drop;
using SchemaBuilder.Core.Interfaces.Add;
using SchemaBuilder.Core.Interfaces.Base;
using SchemaBuilder.Core.Interfaces.Drop;

namespace SchemaBuilder.Core
{
    public abstract class Script
    {
        protected int Id { get; private set; }

        public List<IRoot> Roots => new List<IRoot>();

        public Script(int id)
        {
            Id = id;
        }

        public IAdd Add()
        {
            Add add = new Add();
            Roots.Add(add);
            return add;
        }

        public IDrop Drop()
        {
            Drop drop = new Drop();
            Roots.Add(drop);
            return drop;
        }
    }
}
