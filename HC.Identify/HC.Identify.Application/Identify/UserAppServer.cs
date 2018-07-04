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
    }
}
