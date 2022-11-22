using Microsoft.EntityFrameworkCore;
namespace epitec.Data;

public class ContactStoreContext : DbContext
{
    public ContactStoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Contact> Contacts { get; set; }
}