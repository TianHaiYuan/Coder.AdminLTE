using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlSugar.ORM
{
    
    public class DbContext 
    {
        #region 构造函数
        public DbContext()
        {
            foreach(var conn in ConnStringDic)
            {
                var config = new ConnectionConfig()
                {
                    ConfigId = conn.Key,
                    ConnectionString = ConnStringDic[conn.Key],
                    DbType = DbType.SqlServer,
                    IsAutoCloseConnection = true,//开启自动释放模式和EF一样
                    InitKeyType = InitKeyType.SystemTable,
                };
                ConnectionConfigList.Add(config);
            }
            Db = new SqlSugarClient(ConnectionConfigList);

            //调试SQL事件
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql);//输出sql,查看执行sql
                Console.WriteLine(string.Join(",", pars?.Select(it => it.ParameterName + ":" + it.Value)));//参数
            };
            //操作超时
            Db.Ado.CommandTimeOut = 30;//单位秒
        }
        #endregion
   
        public SqlSugarClient Db { get; }//用来处理事务多表查询和复杂的操作 所有库


        #region 私有成员

        private static List<ConnectionConfig> ConnectionConfigList { get; set; } = new List<ConnectionConfig> { };

        public static Dictionary<string, string> ConnStringDic { get; set; }
        #endregion

    }
}
