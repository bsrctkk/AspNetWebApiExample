namespace AspNetWebApiExample.Models.ORM
{
    public class Student:BaseModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }

        public string EMail { get; set; }
        public string Phone { get; set; }
        public int AdressId { get; set; }
        public Address Adress { get; set; }
    }
}
