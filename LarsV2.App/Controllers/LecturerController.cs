﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class LecturerController : Controller
    {
        [HttpGet]
        public IActionResult Test()
        {
            return null;
        }
    }


}