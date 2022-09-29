using eCodes.Services;
using eCodes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCodes.Models.SearchObjects;
using eCodes.Models.Requests;

namespace eCodes.Controllers
{
    public class WalletController : BaseCRUDController<Models.Wallets, WalletSearchRequest, WalletUpsertRequest, WalletUpsertRequest>
    {
        public WalletController(IWalletsService walletService) : base(walletService)
        {
        }
    }
}
