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
    
    public partial class Firm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Firm()
        {
            this.Job_Opportunities = new HashSet<Job_Opportunity>();
        }
    
        public int FirmID { get; set; }
        public string FirmName { get; set; }
        public string Email { get; set; }
        public int TaxID { get; set; }
        public string Password { get; set; }
        public string FirmAddress { get; set; }
        public string FirmScale { get; set; }
        public string FirmIntro { get; set; }
        public string Contact { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<int> ImageID { get; set; }
    
        public virtual Image Image { get; set; }
        public virtual Status Status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Job_Opportunity> Job_Opportunities { get; set; }
    }
}
