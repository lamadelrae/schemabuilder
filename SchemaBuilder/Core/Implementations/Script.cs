using SchemaBuilder.Core.Implementations.Add;
using SchemaBuilder.Core.Interfaces.Add;

namespace SchemaBuilder.Core
{
    public abstract class Script
    {
        protected int Id { get; private set; }

        public List<IAdd> Additions { get; private set; } = new List<IAdd>();

        public Script(int id)
        {
            Id = id;
        }

        public Add Add()
        {
            Add add = new Add();
            Additions.Add(add);
            return add;
        }
    }
}
