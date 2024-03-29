﻿using eCodes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCodes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class BaseController<T,TSearch>: ControllerBase where T : class where TSearch : class
    {
        public IService<T,TSearch> _service { get; set; }

        public BaseController(IService<T,TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual IEnumerable<T> Get([FromQuery]TSearch search = null)
        {
            return _service.Get(search);
        }
        [HttpGet("{id}")]
        public virtual T GetbyId(int id)
        {
            return _service.GetbyId(id);
        }
    }
}
