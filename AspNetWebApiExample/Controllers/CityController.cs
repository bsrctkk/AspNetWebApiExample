using AspNetWebApiExample.DTOs;
using AspNetWebApiExample.Models.Context;
using AspNetWebApiExample.Models.ORM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetWebApiExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : Controller
    {
        MyContext context;
        public CityController()
        {
            context = new MyContext();
        }
        [HttpGet]
        public List<City> GetAll()
        {
            return context.Cities.Include("Country").ToList();
        }
        [HttpGet("{id}")]
        public City GetByİd(int id)
        {
            return context.Cities.Find(id);
        }
        [HttpPost]
        public City Post(CityDTO cty)
        {
            City citie = new City();
            citie.Name = cty.Name;
            citie.CountryId = cty.CountryId;
            context.Cities.Add(citie);
            context.SaveChanges();
            return citie;
        }
        [HttpDelete]
        public City Delete(int id)
        {
            City citie= context.Cities.Find(id);
            context.Cities.Remove(citie);
            context.SaveChanges();
            return citie;
        }
    }
}
