using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.Requests
{
    public class ProductsUpdateRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string GiftCardKey { get; set; }
        public int ProductTypeId { get; set; }
        public byte[] Picture { get; set; }
        public byte[] PictureThumb { get; set; }
        public string StateMachine { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public int Value { get; set; }
        public string Version { get; set; }
        public string Platform { get; set; }
    }
}
