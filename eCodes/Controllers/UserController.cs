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

        public UserController (IUsersService userService)
            :base(userService)
        {
        }
        //[Authorize("Administrator")]
        public override Users Insert([FromBody] UserInsertRequest insert)
        {
            return base.Insert(insert);
        }

        //[Authorize("Administrator")]
        public override Users Update(int id, [FromBody] UserUpdateRequest update)
        {
            return base.Update(id, update);
        }

    }
}
