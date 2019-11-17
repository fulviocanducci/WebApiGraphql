using System;
using System.Collections.Generic;
namespace WebAppiGraphql.Models
{
  public class People
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public bool Active { get; set; }
    public virtual ICollection<Phone> Phones { get; set; }
  }
}
