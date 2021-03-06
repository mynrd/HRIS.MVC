using Repository;
using System;
using System.Collections.Generic;

namespace HRIS.Data.Entity
{
    public class sys_RoleMenu : EntityBase
    {
        public Guid roleId { get; set; }
        public Guid sourceMenuId { get; set; }
        public string description { get; set; }
        public Guid? parentRoleMenuId { get; set; }
        public int displayOrder { get; set; }
        public Guid updatedBy { get; set; }
        public DateTime updatedDate { get; set; }

        public virtual ICollection<sys_RoleMenu> sys_RoleMenus { get; set; }

        public virtual sys_Menu sys_Menu { get; set; }
        public virtual sys_Role sys_Role { get; set; }
        public virtual sys_RoleMenu sys_RoleMenu_parentRoleMenuId { get; set; }
        public virtual sys_User sys_User_updatedBy { get; set; }

        public sys_RoleMenu()
        {
            displayOrder = 0;
            updatedDate = System.DateTime.Now;
            deleted = false;
            sys_RoleMenus = new List<sys_RoleMenu>();
        }
    }
}