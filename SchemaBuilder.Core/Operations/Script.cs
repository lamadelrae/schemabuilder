using SchemaBuilder.Core.Interfaces.Operations;
using SchemaBuilder.Core.Interfaces.Operations.Add;
using SchemaBuilder.Core.Interfaces.Operations.Drop;
using SchemaBuilder.Core.Interfaces.Operations.Rename;

namespace SchemaBuilder.Core.Operations
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
            var add = new Add.Add();
            Roots.Enqueue(add);
            return add;
        }

        public IDropContract Drop()
        {
            var drop = new Drop.Drop();
            Roots.Enqueue(drop);
            return drop;
        }

        public IRenameContract Rename()
        {
            var rename = new Rename.Rename();
            Roots.Enqueue(rename);
            return rename;
        }
    }
}
