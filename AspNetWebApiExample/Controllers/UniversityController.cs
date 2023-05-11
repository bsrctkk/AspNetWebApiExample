using AspNetWebApiExample.DTOs;
using AspNetWebApiExample.Models.Context;
using AspNetWebApiExample.Models.ORM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetWebApiExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversityController:Controller
    {
        MyContext context;
        public UniversityController()
        {
            context = new MyContext();
        }
        [HttpGet]
        public List<University> GetAll()
        {
            return context.Universities.Include("City").ToList();
        }
        [HttpGet("{id}")]
        public University GetById(int id) 
        {
            return context.Universities.Find(id);
        }
        [HttpPost]
        public University Post(UniversityDTO univers) 
        {
            University uns=new University();
            uns.Name= univers.Name;
            uns.CityId= univers.CityId;
            context.Universities.Add(uns);
            context.SaveChanges();
            return uns;
        }
        [HttpDelete]
        public University Delete(int id) 
        {
            University uns = context.Universities.Find(id);
            context.Universities.Remove(uns);
            context.SaveChanges();
            return uns;
        }
    }
}
