using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZolotoyTelenok
{
    public partial class ZTDBEntities : DbContext
    {
        private static ZTDBEntities _Context;
        
        public static ZTDBEntities GetContext()
        {
            if (_Context == null)
                _Context = new ZTDBEntities();
            return _Context;
        }
    }
}
