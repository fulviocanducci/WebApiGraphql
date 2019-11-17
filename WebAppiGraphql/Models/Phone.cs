namespace WebAppiGraphql.Models
{
  public class Phone
  {
    public int Id { get; set; }
    public int PeopleId { get; set; }
    public virtual People People { get; set; }
    public string Ddd { get; set; }
    public string Number { get; set; }
  }
}
