using System;
using System.Collections.Generic;
using System.Linq;
using SqlSugar;
namespace SqlSugar.ORM
{
    /// <summary>
    /// ≤‚ ‘±Ì
    ///</summary>
    [SugarTable("Test")]
    public class Test
    {
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "ID", IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "UserID")]
        public int UserID { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "Amout")]
        public int Amout { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "PrizePropType")]
        public int PrizePropType { get; set; }
        /// <summary>
        ///  
        ///</summary>
        [SugarColumn(ColumnName = "Desc")]
        public string Desc { get; set; }
    }
}
