//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.Collections.Generic;
    
    [MetadataType(typeof(Product_TagsMetaData))]
    public partial class Product_Tags
    {
        public int TagID { get; set; }
        public int ProductID { get; set; }
        public string Tag { get; set; }
    
        public virtual Products Products { get; set; }
    }
}
