//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class VideoSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VideoSet()
        {
            this.HistorySet = new HashSet<HistorySet>();
            this.PlaylistSet = new HashSet<PlaylistSet>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public System.DateTime UploadTime { get; set; }
        public string Description { get; set; }
        public float Length { get; set; }
        public int Views { get; set; }
        public Nullable<int> Likes { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistorySet> HistorySet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlaylistSet> PlaylistSet { get; set; }
        public virtual UserSet UserSet { get; set; }
    }
}