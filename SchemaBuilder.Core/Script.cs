using SchemaBuilder.Core.Interfaces.Operations;
using SchemaBuilder.Core.Interfaces.Operations.Add;
using SchemaBuilder.Core.Interfaces.Operations.Drop;
using SchemaBuilder.Core.Operations.Add;
using SchemaBuilder.Core.Operations.Drop;

namespace SchemaBuilder.Core
{
    public abstract class Script
    {
        internal int Id { get; private set; }

        internal Queue<IBaseDataStore> Roots { get; private set; } = new Queue<IBaseDataStore>();

        public Script(int id)
        {
            Id = id;
        }

        public IAddContract Add()
        {
            var add = new Add();
            Roots.Enqueue(add);
            return add;
        }

        public IDropContract Drop()
        {
            var drop = new Drop();
            Roots.Enqueue(drop);
            return drop;
        }
    }
}
