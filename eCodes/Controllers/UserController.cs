using eCodes.Models;
using eCodes.Models.Requests;
using eCodes.Models.SearchObjects;
using eCodes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCodes.Controllers
{
    public class UserController : BaseCRUDController<Models.Users, UserSearchObject,UserInsertRequest,UserUpdateRequest>
    {
        public IUsersService _userService { get; set; }
        public UserController (IUsersService userService)
            :base(userService)
        {
            _userService = userService;
        }
        public override Users Insert([FromBody] UserInsertRequest insert)
        {
            return base.Insert(insert);
        }

        public override Users Update(int id, [FromBody] UserUpdateRequest update)
        {
            return base.Update(id, update);
        }
        [HttpGet("GetAccType")]
        public string GetAccType(string username)
        {
            return _userService.GetAccType(username);
        }

    }
}
