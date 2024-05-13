using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_API__2023.Models;   

namespace API_API__2023.Controllers
{
    public class apiEmpController : ApiController
    {
        api2023Entities _db = new api2023Entities();

        [HttpPost]
       public IHttpActionResult employeeInsert(tblemployee _emp)
        {
            _db.tblemployees.Add(_emp);
            _db.SaveChanges();
            return Ok();
        }

        [HttpGet] 
        public IHttpActionResult employeeShow()
        {
            var data = _db.tblemployees.ToList();
            return Ok(data);
        }
    }
}
