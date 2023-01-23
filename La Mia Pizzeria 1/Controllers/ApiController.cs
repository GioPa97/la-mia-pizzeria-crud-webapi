﻿using La_Mia_Pizzeria_1.Database;
using La_Mia_Pizzeria_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace La_Mia_Pizzeria_1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApiPizzeController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                List<Pizza> pizze = db.Pizze.ToList<Pizza>();
                return Ok(pizze);
            }
        }

    }
}