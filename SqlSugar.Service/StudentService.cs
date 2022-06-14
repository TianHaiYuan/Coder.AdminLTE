using SqlSugar.ORM;
using System.Collections.Generic;
using System.Linq;

namespace SqlSugar.Service
{
    public class StudentService : BaseDbContext<Student>
    {
        public List<Student> GetList()
        {
            QueryTest();
            return Base_Table.GetList();
        }

        public void QueryTest()
        {
            var a = Base_Table.GetList();
            //多表跨库
            var list1 = Db.Queryable<Student>()//.AS("AccountDb.dbo.Student") 
                    .LeftJoin<Order>((s, o) => s.StuId==o.StuId).AS<Order>("OrderDb.dbo.Order") //AS<T>
                    .Select((s, o) => new { s.StuId,s.Name,o.OrderId,o.RealAmount,o.CreateTime})
                    .ToList();

            Db.Queryable<Student>().Where(stu => stu.Id == 1).ToList();
            Db.Queryable<Student>().Where(it => it.Id > 10 && it.Name == "a").ToList();
            var exp = Expressionable.Create<Student>();
            exp.OrIF(1>0, it => it.Id == 1);        //.OrIf 是条件成立才会拼接OR
            exp.Or(it => it.Name.Contains("jack"));              //拼接OR
            Db.Queryable<Student>().Where(exp.ToExpression()).ToList();
            Db.Queryable<Student>().Where(it => it.Name.Contains("jack")).ToList(); //模糊查询
            Db.Queryable<Student>().InSingle(2);                //通过主键查询 SingleById
            Db.Queryable<Student>().Single(it => it.Id == 2); //根据ID查询
            Db.Queryable<Student>().First(it => it.Id == 1);  //没有返回Null
            Db.Queryable<Student>().Take(10).ToList();          //前10条
            Db.Queryable<Student>().Where(it => it.Id > 11).Count(); //记录数                                                           
            Db.Queryable<Student>().AS("Student").ToList(); //更新表名 生成的SQL  SELECT [ID],[NAME] FROM  Student                                              
            Db.Queryable<Student>().AS("dbo.Student").ToList();//生成的SQL  SELECT [ID],[NAME] FROM  dbo.School
            _ = Db.Queryable<Student>().Where(it => it.Id > 11).Any();
            _ = Db.Queryable<Student>().Any(it => it.Id > 11); //上面语法的简化
            int[] allIds = new int[] { 2, 3, 31 };
            Db.Queryable<Student>().Where(it => allIds.Contains(it.Id)).ToList(); //Id in (2,3,31)
            Db.Queryable<Student>().OrderBy(st => st.Id, OrderByType.Desc).ToList(); //排序
            Db.Queryable<Student>().Select(it => it.Name).ToList();//单值 查询列 查询单独列
            Db.Queryable<Student>().ToList();
        }

    }
}
