using HC.Identify.Core.Identify;
using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Identify.Dto.Identify
{
    public class UserDto
    {
        public int Id { get; set; }

        public RoleEnum Role { get; set; }

        public string Name { get; set; }

        public string RoleName
        {
            get
            {
                return Role.ToString();
            }
        }
    }
}
