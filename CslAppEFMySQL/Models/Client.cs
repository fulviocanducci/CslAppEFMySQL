using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CslAppEFMySQL.Models
{
   [Table("clients")]
   public class Client
   {
      public Client() : this(0, string.Empty, new HashSet<Phone>()) { }
      public Client(string name) : this(0, name, new HashSet<Phone>()) { }
      public Client(int id, string name) : this(id, name, new HashSet<Phone>()) { }
      public Client(string name, ICollection<Phone> phones) : this(0, name, phones) { }
      public Client(int id, string name, ICollection<Phone> phones)
      {
         Id = id;
         Name = name ?? throw new ArgumentNullException(nameof(name));
         Phones = phones ?? throw new ArgumentNullException(nameof(phones));
      }

      [Key()]
      [Column("id")]
      public int Id { get; set; }

      [Column("name")]
      public string Name { get; set; }

      public virtual ICollection<Phone> Phones { get; set; }
   }
}
