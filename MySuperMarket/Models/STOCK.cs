//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MySuperMarket.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class STOCK
    {
        public string STOCK_ID { get; set; }
        public string BATCH_ID { get; set; }
        public string PLAN_ID { get; set; }
        public string EXPENSE_ID { get; set; }
        public Nullable<int> STOCK_NUM { get; set; }
        public Nullable<System.DateTime> STOCK_DATE { get; set; }
    
        public virtual EXPENSE EXPENSE { get; set; }
        public virtual PLAN PLAN { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
    }
}