using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using La_Mia_Pizzeria_1.Database;
using La_Mia_Pizzeria_1.Models;
using System.Security.Permissions;

namespace La_Mia_Pizzeria_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticoliController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? search)
        {

            using (PizzeriaContext db = new PizzeriaContext())
            {
                List<Pizza> articoli = new List<Pizza>();

                if (search is null || search == "")
                {
                    articoli = db.Pizze.ToList<Pizza>();
                }
                else
                {
                    // converto tutto in stringa minuscola, non mi interessano le lettere maiuscole
                    search = search.ToLower();

                    articoli = db.Pizze.Where(articolo => articolo.Title.ToLower().Contains(search))
                                       
                                       .ToList<Pizza>();
                }

                return Ok(articoli);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza articolo = db.Pizze.Where(articolo => articolo.Id == id).FirstOrDefault();

                if (articolo is null)
                {
                    return NotFound("L'articolo con questo id non è stato trovato!");
                }

                return Ok(articolo);
            }
        }


    }
}
