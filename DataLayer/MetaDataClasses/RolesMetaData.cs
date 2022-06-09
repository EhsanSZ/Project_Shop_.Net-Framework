using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class RolesMetaData
    {
        [Key]
        public int RoleID { get; set; }

        [Display(Name = "عنوان نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string RoleTitle { get; set; }

        [Display(Name = "عنوان سیستمی نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string RoleName { get; set; }
    }


    //[MetadataType(typeof(RolesMetaData))]
    //public partial class Roles
    //{

    //}
}



//USE MyEShop
//GO

//CREATE TABLE Roles
//(
//	RoleID INT NOT NULL ,
//	RoleTitle NVARCHAR(250) NOT NULL,
//	RoleName VARCHAR(150) NOT NULL
//)
//GO

//ALTER TABLE Roles ADD CONSTRAINT PK_Roles
//PRIMARY KEY CLUSTERED (RoleID)
//GO

//INSERT INTO Roles (RoleID , RoleTitle, RoleName )
//VALUES(1, 'کاربران عادی', 'user')
//GO

//INSERT INTO Roles (RoleID , RoleTitle, RoleName )
//VALUES(2, 'مدیر کل سیستم', 'admin')
//GO




