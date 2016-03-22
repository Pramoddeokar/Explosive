using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngEdu.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        ngEduContext dbContext;

        public ngEduContext Init()
        {
            return dbContext ?? (dbContext = new ngEduContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
