using eCodes.Models.Requests;
using eCodes.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCodes.Services
{
    public interface IWalletsService: ICRUDService<Models.Wallets,WalletSearchRequest,WalletUpsertRequest,WalletUpsertRequest>
    {

    }
}
