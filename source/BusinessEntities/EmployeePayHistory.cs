//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessEntities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using IronFramework.Utility.EntityFramewrok;
    
    [DataContract]
    public partial class EmployeePayHistory : IEntity
    {
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public System.DateTime RateChangeDate { get; set; }
        [DataMember]
        public decimal Rate { get; set; }
        [DataMember]
        public byte PayFrequency { get; set; }
        [DataMember]
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual Employee Employee { get; set; }
    
        #region IEntity Members
    
        public State State { get; set; }
    
        #endregion
    }
}
