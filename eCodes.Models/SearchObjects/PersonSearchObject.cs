using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.SearchObjects
{
    public class PersonSearchObject : BaseSearchObject
    {
        public string NameFTS { get; set; }
        public string Jmbg { get; set; }
        public string Gender { get; set; }
    }
}
