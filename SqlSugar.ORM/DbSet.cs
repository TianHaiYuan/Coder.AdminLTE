using System;
using System.Collections.Generic;
using System.Text;

namespace SqlSugar.ORM
{
    //我们就来扩展一个SimpleClient取名叫DbSet
    public class DbSet<T> : SimpleClient<T> where T : class, new()
    {
        public DbSet(SqlSugarClient context) : base(context)
        {

        }
        //SimpleClient中的方法满足不了你，你可以扩展自已的方法
        public List<T> GetByIds(dynamic[] ids)
        {
            return Context.Queryable<T>().In(ids).ToList();
        }
    }
}
