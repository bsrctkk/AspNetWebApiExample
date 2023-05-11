namespace AspNetWebApiExample.Models.ORM
{
    public class City:BaseModel
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }    
    }
}
