namespace AspNetWebApiExample.Models.ORM
{
    public class Address:BaseModel
    {
        public string Name { get; set; }

        public string Street { get; set; }

        public string Description { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }  
    }
}
