//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Groot
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderProducts = new HashSet<OrderProduct>();
        }
    
        public int OrderID { get; set; }
        public int MemberID { get; set; }
        public string ShipName { get; set; }
        public System.DateTime OrderDate { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public Nullable<System.DateTime> ShippingDate { get; set; }
        public Nullable<System.DateTime> CompletedDate { get; set; }
        public int PaymentID { get; set; }
        public int ShipID { get; set; }
        public Nullable<int> Zipcode { get; set; }
        public string ShipAddress { get; set; }
        public string Note { get; set; }
        public int StatusID { get; set; }
    
        public virtual Member Member { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual RegionDistrict RegionDistrict { get; set; }
        public virtual ShipMethod ShipMethod { get; set; }
        public virtual Status Status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
