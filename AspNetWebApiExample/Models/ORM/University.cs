namespace AspNetWebApiExample.Models.ORM
{
    public class University : BaseModel
    {
        public string Name { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }  
    }
}