//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MULEWcfServiceLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class positioning
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public positioning()
        {
            this.mappings = new HashSet<mapping>();
        }
    
        public int position_id { get; set; }
        public int post_id { get; set; }
        public string region { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double northing { get; set; }
        public double easting { get; set; }
        public double euv_depth { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mapping> mappings { get; set; }
        public virtual post post { get; set; }
    }
}
