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
    
    public partial class PlaylistSet
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int VideoId { get; set; }
        public string Name { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
    
        public virtual UserSet UserSet { get; set; }
        public virtual VideoSet VideoSet { get; set; }
    }
}
