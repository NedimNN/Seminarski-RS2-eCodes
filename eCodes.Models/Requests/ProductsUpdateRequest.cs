using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCodes.Models.Requests
{
    public class ProductsUpdateRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public decimal Price { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string GiftCardKey { get; set; }
        public int ProductTypeId { get; set; }
        public byte[] Picture { get; set; }
        public string StateMachine { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }
        public string Duration { get; set; }
        public int Value { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Version { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Platform { get; set; }
    }
}
