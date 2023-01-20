using CslAppEFMySQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CslAppEFMySQL
{
   internal class Program
   {
      static void Main(string[] args)
      {
         using DataAccess access = new();
         //var clients = access.Client.Include(a => a.Phones.Where(a => a.Active)).FirstOrDefault(c => c.Id == 2);

         var item = access.Client
            .Where(c => c.Id == 2)
            .Select(s => new
            {
               s.Id,
               s.Name,
               Phones = s.Phones.Where(a => a.Active)
            })
            .FirstOrDefault();

         //access.Attach(clients)
         //   .Collection(a => a.Phones)
         //   .Query()
         //   .Where(c => c.Active)
         //   .Load();
      }
   }
}