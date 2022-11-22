using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using epitec.Data;
using Newtonsoft.Json;
using System.Text;
namespace epitec.Controllers;

[Route("contacts")]
[ApiController]
public class ContactController : Controller
{
    private ContactStoreContext _db;

    public ContactController(ContactStoreContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Contact>>> GetContacts()
    {
        return (await _db.Contacts.ToListAsync()).OrderBy(s => s.LastName).ToList();
    }

    [HttpPost]
    public async Task<ActionResult<Contact>> PostContact(Contact contact)
    {
        _db.Contacts.Add(contact);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetContacts), new { id = contact.Id }, contact);
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<Contact>> GetContactPage(int Id)
    {
        // Console.WriteLine(contactId);
        var order = await _db.Contacts
            .Where(o => o.Id == Id)
            .SingleOrDefaultAsync();
        
        if (order == null)
        {
            return NotFound();
        }

        return order;
    }

    [HttpDelete("{Id:int}")]
    public async Task<ActionResult<Contact>> DeleteContact(int Id)
    {
        var contact = await _db.Contacts.FindAsync(Id);
        if (contact == null)
        {
            return NotFound();
        }

        _db.Remove(contact);
        await _db.SaveChangesAsync();

        return NoContent();
    }


    [HttpPut("{Id:int}")]
    public async Task<ActionResult<Contact>> UpdateContact(int Id, Contact c)
    {
        var contact = await _db.Contacts.FindAsync(Id);
        if (contact == null)
        {
            return NotFound();
        }
        contact.FirstName = c.FirstName;
        contact.LastName = c.LastName;
        contact.BirthDate = c.BirthDate;
        contact.PhoneNumber = c.PhoneNumber;

        _db.Update(contact);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}