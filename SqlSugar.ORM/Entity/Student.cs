using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SqlSugar.ORM
{
    public  class Student
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]//数据库是自增才配自增 
        public int Id { get; set; }
        public int StuId { get; set; }
        public string Name { get; set; }
        public int? CourseId { get; set; }
    }
}
