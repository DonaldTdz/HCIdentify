using HC.Identify.Dto.Identify;
using HC.Identify.EntityFramework.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Identify.EntityFramework.Services.Identify
{
    public class UserService
    {
        public IList<UserDto> GetUserList()
        {
            using (IdentifyContext context = new IdentifyContext())
            {
                var query = context.Users.Select(u => new UserDto()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Role = u.Role
                });

                return query.ToList();
            }
        }
    }
}
