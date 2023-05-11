using AspNetWebApiExample.DTOs;
using AspNetWebApiExample.Models.Context;
using AspNetWebApiExample.Models.ORM;
using Microsoft.AspNetCore.Mvc;

namespace AspNetWebApiExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController:Controller
    {
        MyContext context;
        public CountryController()
        {
            context = new MyContext();
        }
        [HttpGet]
        public List<Country> GetAll() 
        {
            return context.Countries.ToList();  
        }
        [HttpGet("{id}")]
        public Country GetById(int id) 
        {
            return context.Countries.Find(id);
        }
        [HttpPost]
        public Country Post(CountryDTO ctr) 
        {
            Country country = new Country();
            country.Name = ctr.Name;
            context.Countries.Add(country);
            context.SaveChanges();
            return country;
        }
        [HttpDelete]
        public Country Delete(int id) 
        {
            Country country = context.Countries.Find(id);
            context.Countries.Remove(country);
            context.SaveChanges();
            return country;
        }
    }
}
