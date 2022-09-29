using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCodes.Models.Requests
{
    public class ProductsInsertRequest
    {
        [Required(AllowEmptyStrings =false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Code { get; set; }
        [Required(AllowEmptyStrings = false)]
        public decimal Price { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string GiftCardKey { get; set; }
        public int ProductTypeId { get; set; }
        public byte[] Picture { get; set; }
        public byte[] PictureThumb { get; set; }
        public string StateMachine { get; set; }
        public string Description { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Duration { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int Value { get; set; }
        public string Version { get; set; }
        public string Platform { get; set; }
        public int SellerId { get; set; }

    }
}
