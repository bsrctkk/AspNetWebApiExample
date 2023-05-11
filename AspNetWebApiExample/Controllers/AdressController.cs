using AspNetWebApiExample.DTOs;
using AspNetWebApiExample.Models.Context;
using AspNetWebApiExample.Models.ORM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetWebApiExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdressController:Controller
    {
        MyContext context;
        public AdressController()
        {
            context = new MyContext();
        }
        [HttpGet]
        public List<Address> GetAll()
        {
            return context.Adress.Include("City").ToList();
        }
        [HttpGet("{id}")]
        public Address GetById(int id) 
        {
            return context.Adress.Find(id);
        }
        [HttpPost]
        public Address Post(AddressDTO adr) 
        {
            Address adres=new Address();
            adres.Name = adr.Name;
            adres.Street=adr.Street;
            adres.Description=adr.Description;
            adres.CityId=adr.CityId;

            context.Adress.Add(adres);
            context.SaveChanges();
            return adres;
        }
        [HttpDelete]
        public Address Delete(int id) 
        {
            Address adres=context.Adress.Find(id);
            context.Adress.Remove(adres);
            context.SaveChanges();
            return adres;
        }
    }
}
