//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB_GamingForm_Show
{
    using System;
    using System.Collections.Generic;
    
    public partial class Resume
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Resume()
        {
            this.ResumeCertificates = new HashSet<ResumeCertificate>();
            this.ResumeSkills = new HashSet<ResumeSkill>();
            this.JobResumes = new HashSet<JobResume>();
        }
    
        public int ResumeID { get; set; }
        public int MemberID { get; set; }
        public string FullName { get; set; }
        public string IdentityID { get; set; }
        public string PhoneNumber { get; set; }
        public string ResumeContent { get; set; }
        public string WorkExp { get; set; }
        public int FormID { get; set; }
        public Nullable<int> ResumeStatusID { get; set; }
        public Nullable<int> ImageID { get; set; }
        public Nullable<int> EDID { get; set; }
    
        public virtual Education Education { get; set; }
        public virtual Image Image { get; set; }
        public virtual Member Member { get; set; }
        public virtual ResumeStyle ResumeStyle { get; set; }
        public virtual Status Status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResumeCertificate> ResumeCertificates { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResumeSkill> ResumeSkills { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobResume> JobResumes { get; set; }
    }
}
