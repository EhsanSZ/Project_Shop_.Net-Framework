//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class FeaturesMetaData
    {
        [Key]
        public int FeatureID { get; set; }

        [Display(Name = "ویژگی ها")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FeatureTitle { get; set; }
    }
}


//CREATE TABLE Features
//(
//	FeatureID INT NOT NULL IDENTITY(1,1) , 
//	FeatureTitle NVARCHAR(150) NOT NULL
//)
//GO

//ALTER TABLE Features ADD CONSTRAINT PK_Features
//PRIMARY KEY CLUSTERED (FeatureID)
//GO

//ALTER TABLE Features ADD CONSTRAINT UK_Features
//UNIQUE NONCLUSTERED (FeatureTitle)
//GO