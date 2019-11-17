using System;
namespace WebAppiGraphql.Models
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Active { get; set; }
    }
}
