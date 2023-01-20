using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CslAppEFMySQL.Models
{
   [Table("phones")]
   public class Phone
   {
      public Phone(): this(0, 0, "", true) { }
      public Phone(int clientId, string number, bool active) : this(0, clientId, number, active) { }
      public Phone(Client client, string number, bool active) : this(0, client.Id, number, active) 
      {
         Client = client;
      }

      public Phone(int id, int clientId, string number, bool active)
      {
         Id = id;
         ClientId = clientId;
         Number = number ?? throw new ArgumentNullException(nameof(number));
         Active = active;
      }

      [Key()]
      [Column("id")]
      public int Id { get; set; }

      [Column("client_id")]
      public int ClientId { get; set; }

      [ForeignKey("ClientId")]
      public virtual Client Client { get; set; }

      [MaxLength(15)]
      [Column("number")]
      public string Number { get; set; }

      [Column("active")]
      public bool Active { get; set; }
   }
}
