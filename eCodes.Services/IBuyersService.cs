using eCodes.Models.Requests;
using eCodes.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCodes.Services
{
    public interface IBuyersService : ICRUDService<Models.Buyers,BuyersSearchObject,BuyerInsertRequest,BuyerUpdateRequest>
    {
        Models.Buyers Login(string username, string password);


    }
}
