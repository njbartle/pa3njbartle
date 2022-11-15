using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using api.models;
using api.database;
using api.interfaces;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        // GET: api/Driver
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Driver> Get()
        {
            IGetAllDrivers dataHandler = new ReadDriverData();
            return dataHandler.GetAllDrivers();
        }

        // GET: api/Driver/5
        [EnableCors("OpenPolicy")]        
        [HttpGet]
        [Route("{id}")]
        public Driver Get(int id)
        {
            IGetDriver dataHandler = new ReadDriverData();
            return dataHandler.GetDriver(id);
        }

        // POST: api/Driver
        [EnableCors("OpenPolicy")]        
        [HttpPost]
        public void Post([FromBody] Driver driver)
        {
             IInsertDriver dataHandler = new ReadDriverData();
             dataHandler.InsertDriver(id);
        }

        // PUT: api/Driver/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Driver/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
