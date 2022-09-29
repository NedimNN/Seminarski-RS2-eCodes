using AutoMapper;
using eCodes.Models;
using eCodes.Models.Requests;
using eCodes.Models.SearchObjects;
using eCodes.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCodes.Services
{
    public class WalletsService : BaseCRUDService<Models.Wallets, Database.Wallet, WalletSearchRequest, WalletUpsertRequest, WalletUpsertRequest>, IWalletsService
    {
        public WalletsService(_210331Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IQueryable<Wallet> AddFilter(IQueryable<Wallet> query, WalletSearchRequest search = null)
        {
            var filter = base.AddFilter(query, search);

            if(search?.BuyerId > 0)
            {
                filter = filter.Where(w=> w.BuyerId.Equals(search.BuyerId));
            }

            return filter;
        }


    }
}
