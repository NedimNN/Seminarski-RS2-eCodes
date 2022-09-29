using eCodes.Services;
using eCodes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCodes.Models.SearchObjects;
using eCodes.Models.Requests;
using eCodes.Services.HelperMethods;

namespace eCodes.Controllers
{
    public class EmployeeController : BaseCRUDController<Models.Employees, EmployeeSearchObject, EmployeeInsertRequest, EmployeeUpdateRequest>
    {
        public EmployeeController(IEmployeeService employeeService) : base(employeeService)
        {
        }

    }
}
