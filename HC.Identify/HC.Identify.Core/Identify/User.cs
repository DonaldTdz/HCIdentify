using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HC.Identify.Core.Identify
{
    [Table("Users", Schema = "dbo")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        public RoleEnum Role { get; set; }

        public string Name { get; set; }
    }

    public enum RoleEnum
    {
        系统管理员 = 1,
        操作员 = 2
    }
}
