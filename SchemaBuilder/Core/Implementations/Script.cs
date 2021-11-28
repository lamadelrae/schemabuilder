using SchemaBuilder.Core.Implementations.Add;
using SchemaBuilder.Core.Implementations.Drop;
using SchemaBuilder.Core.Implementations.Rename;
using SchemaBuilder.Core.Interfaces.Contracts.Roots.Add;
using SchemaBuilder.Core.Interfaces.Contracts.Roots.Drop;
using SchemaBuilder.Core.Interfaces.Contracts.Roots.Rename;
using SchemaBuilder.Core.Interfaces.DataHolders.Roots;

namespace SchemaBuilder.Core
{
    public abstract class Script
    {
        protected int Id { get; private set; }

        public List<IRootDataHolder> Roots => new List<IRootDataHolder>();

        public Script(int id)
        {
            Id = id;
        }

        public IAddContract Add()
        {
            Add add = new Add();
            Roots.Add(add);
            return add;
        }

        public IDropContract Drop()
        {
            Drop drop = new Drop();
            Roots.Add(drop);
            return drop;
        }

        public IRenameContract Rename()
        {
            Rename rename = new Rename();
            Roots.Add(rename);
            return rename;
        }
    }
}
