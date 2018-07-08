using HC.Identify.Core.Identify;
using HC.Identify.Dto.Identify;
using HC.Identify.EntityFramework.DBContexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                    Account = u.Account,
                    Role = u.Role
                });

                return query.ToList();
            }
        }

        public IList<UserDto> GetUserListByQuery(string userName)
        {
            using (IdentifyContext context = new IdentifyContext())
            {
                var parameter = "";
                List<SqlParameter> paras = new List<SqlParameter>();
                if (!string.IsNullOrEmpty(userName))
                {
                    parameter += " and Name like @UserName";
                    paras.Add(new SqlParameter("@UserName", "%" + userName + "%"));
                }

                var sql = string.Format("select * from dbo.Users where 1=1{0}", parameter);
                var result = context.Database.SqlQuery<UserDto>(sql, paras.ToArray()).ToList();
                return result;
            }
        }
    }
}
