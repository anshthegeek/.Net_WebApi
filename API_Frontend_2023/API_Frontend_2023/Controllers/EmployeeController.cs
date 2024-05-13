using API_Frontend_2023.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace API_Frontend_2023.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(EmployeeModel _empmodel)
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44385/api/apiEmp");
            string data = JsonConvert.SerializeObject(_empmodel);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            _client.PostAsync(_client.BaseAddress, content);

            return View();
        }


        public ActionResult Show()
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44385/api/apiEmp");
            List<EmployeeModel> lstemp = new List<EmployeeModel>();
             HttpResponseMessage msg= _client.GetAsync(_client.BaseAddress).Result;
            if (msg.IsSuccessStatusCode)
            {
                var content = msg.Content.ReadAsStringAsync().Result;
                var jdata = JsonConvert.DeserializeObject(content).ToString();
                lstemp = JsonConvert.DeserializeObject<List<EmployeeModel>>(jdata);
            }
            return View(lstemp);
        }
    }
}