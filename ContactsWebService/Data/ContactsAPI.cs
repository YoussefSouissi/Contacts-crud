using ContactsWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsWebService.Data
{
    public class ContactsAPI : DbContext
    {
        public ContactsAPI(DbContextOptions options):base (options) { 
        
        }

        public DbSet<Contacts> ContactsList { get; set; }

    }
}
