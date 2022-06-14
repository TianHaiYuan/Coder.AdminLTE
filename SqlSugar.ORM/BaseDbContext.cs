using System;
using System.Collections.Generic;
using System.Text;

namespace SqlSugar.ORM
{
    //创建一个BaseDbContext类，使用DbSet(或者SimpleClient)
    public class BaseDbContext<T> : DbContext where T:class ,new ()
    {
        //单个表简单操作对象
        public DbSet<T> Base_Table { get { return new DbSet<T>(Db); } }
    }
}
