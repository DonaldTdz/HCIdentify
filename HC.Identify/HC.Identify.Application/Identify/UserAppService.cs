using HC.Identify.Dto.Identify;
using HC.Identify.EntityFramework.Services.Identify;
using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Identify.Application.Identify
{
    public class UserAppService : IdentifyAppServiceBase
    {
        private UserService userService;

        public UserAppService()
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

        /// <summary>
        /// 查询所有用户信息
        /// </summary>
        /// <returns></returns>
        public IList<UserDto> GetAllUser()
        {
            var result = userService.GetAllUser();
            return result;
        }
        public UserDto GetSigleUser(string name, string password)
        {
            var result = userService.GetSigleUser(name,password);
            return result;
        }
    }
}
