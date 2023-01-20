using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySqlConnector.Logging;

namespace CslAppEFMySQL.Models
{
   public class DataAccess : DbContext
   {
      public DbSet<Client> Client { get; set; }
      public DbSet<Phone> Phone { get; set; }

      public static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(c => c.AddConsole());

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder
            .UseLoggerFactory(ConsoleLoggerFactory)
            .EnableSensitiveDataLogging()
            .UseMySql("Server=127.0.0.1;Database=mydb;Uid=root;Pwd=senha;SslMode=None;CharSet=utf8;", new MySqlServerVersion(new Version(8, 0, 0)), options =>
         {

         });
      }
   }
}
