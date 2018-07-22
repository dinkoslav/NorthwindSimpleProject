using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fourth.Data.DataHandlers
{
    public abstract class BaseDataHandler
    {
        protected BaseDataHandler(INorthwindData data)
        {
            this.Data = data;
        }

        protected INorthwindData Data { get; private set; }
    }
}
