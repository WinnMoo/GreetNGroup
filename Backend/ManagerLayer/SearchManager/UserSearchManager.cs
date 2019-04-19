﻿using DataAccessLayer.Tables;
using ServiceLayer.Interface;
using ServiceLayer.Services;

namespace ManagerLayer.SearchManager
{
    class UserSearchManager : ISearchable<User>
    {
        private readonly IUserService _userService = new UserService();

        // Implements interface within this region
        #region Interface Implementation

        public User SearchByName(string name)
        {
            return _userService.GetUserByUsername(name);
        }

        public User SearchById(int id)
        {
            return _userService.GetUserById(id);
        }

        #endregion
    }
}