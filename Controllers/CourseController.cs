using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CourseController : Controller
    {
        [HttpGet]
        public IActionResult Test()
        {
            IEnumerable<TestObject> list = new List<TestObject>()
            {
                new TestObject { Name = "Christian", Age = 50 },
                new TestObject { Name = "Mouse", Age = 20 }
            };

            return Ok(list);
        }
    }

    internal class TestObject
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
