using AspNetWebApiExample.DTOs;
using AspNetWebApiExample.Models.Context;
using AspNetWebApiExample.Models.ORM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetWebApiExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController:Controller
    {
        MyContext context;

        public StudentController()
        {
            context = new MyContext();
        }
        [HttpGet]
        public List<Student> GetAll()
        {
            return context.Students.Include("Adress").ToList();
        }
        [HttpGet("{id}")]
        public Student GetById(int id) 
        {
            return context.Students.Find(id);
        }
        [HttpPost]
        public Student Post(StudentDTO std) 
        {
            Student student = new Student();
            student.Name = std.Name;
            student.SurName = std.Surname;
            student.EMail = std.Email;
            student.Phone= std.Phone;
            student.AdressId = std.AdressId;

            context.Students.Add(student);
            context.SaveChanges();
            return student;
        }
        [HttpDelete]
        public Student DeleteById(int id) 
        {
            Student student=context.Students.Find(id);
            context.Students.Remove(student);
            context.SaveChanges();
            return student;
        }
    }
}
