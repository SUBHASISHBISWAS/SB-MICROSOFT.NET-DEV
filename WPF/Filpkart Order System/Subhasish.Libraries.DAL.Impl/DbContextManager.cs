using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.DAL.Impl
{
    public static class DbContextManager
    {
        public static OrderSystemContext GetContext()
        {
            return new OrderSystemContext();
        }
    }
}
