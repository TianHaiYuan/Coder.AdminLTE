using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace SqlSugar.ORM
{
    /// <summary>
    /// 
    ///</summary>
    [SugarTable("Order")]
    public class Order
    {
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="ID" ,IsPrimaryKey = true ,IsIdentity = true  )]
         public int ID { get; set; }
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="OrderId"    )]
         public string OrderId { get; set; }
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="CreateTime"    )]
         public DateTime CreateTime { get; set; }
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="PayTime"    )]
         public DateTime? PayTime { get; set; }
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="SendGoodsTime"    )]
         public DateTime? SendGoodsTime { get; set; }
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="TotalAmount"    )]
         public decimal TotalAmount { get; set; }
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="RealAmount"    )]
         public decimal RealAmount { get; set; }
        /// <summary>
        ///  
        ///</summary>
         [SugarColumn(ColumnName="StuId"    )]
         public int StuId { get; set; }
    }
}
