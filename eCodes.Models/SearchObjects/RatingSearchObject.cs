using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.SearchObjects
{
    public class RatingSearchObject: BaseSearchObject
    {
        public int SellerId { get; set; }
        public int ProductId { get; set; }


    }
}
