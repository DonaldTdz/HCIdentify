using HC.Identify.Dto.Identify;
using HC.Identify.EntityFramework.Services.Identify;
using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Identify.Application.Identify
{
    public class UserAppServer
    {
        private UserService userService;

        public UserAppServer()
        {
            userService = new UserService();
        }

        public IList<UserDto> GetUserList()
        {
            return userService.GetUserListByQuery("唐");
            //return userService.GetUserList();
        }

        /// <summary>
        /// 查询当前登录的用户是否存在
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public bool  UserIsExtend(string name,string password)
        {
            var result = userService.GetSingleUserByNamePas(name, password);
            return result.Count != 0;
        }

    }
}
