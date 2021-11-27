using SchemaBuilder.Core.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaBuilder.Core.Interfaces.Rename
{
    public interface IRenameTable : IOperation
    {
        public IRenameColumn To(string columnName);

        public void In(string tableName);
    }
}
