using eCodes.Services;
using eCodes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCodes.Models.SearchObjects;
using eCodes.Models.Requests;

namespace eCodes.Controllers
{
    
    public class PersonsController : BaseCRUDController<Models.Persons, PersonSearchObject, PersonInsertRequest, PersonUpdateRequest>
    {

        public PersonsController(IPersonsService personService)
            :base(personService)
        {
            
        }
      
    }
}
