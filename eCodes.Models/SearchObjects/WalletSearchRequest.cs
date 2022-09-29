using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.SearchObjects
{
    public class WalletSearchRequest : BaseSearchObject
    {
        public int BuyerId { get; set; }
    }
}
