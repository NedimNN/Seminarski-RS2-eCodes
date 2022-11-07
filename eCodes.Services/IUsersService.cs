using eCodes.Models;
using eCodes.Models.Requests;
using eCodes.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Services
{
    public interface IUsersService : ICRUDService<Users, UserSearchObject, UserInsertRequest, UserUpdateRequest>
    {
        Models.Users Login(string username, string password);
        string GetAccType(string username);
    }
}
