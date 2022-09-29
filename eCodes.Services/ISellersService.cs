using eCodes.Models.Requests;
using eCodes.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCodes.Services
{
    public interface ISellersService : ICRUDService<Models.Sellers,SellerSearchObject,SellerInsertRequest,SellerUpdateRequest>
    {
        Models.Sellers Login(string username, string password);
        Models.Sellers RequestDelete (int id);

    }
}
