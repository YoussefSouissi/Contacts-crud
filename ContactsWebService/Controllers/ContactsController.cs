using ContactsWebService.Data;
using ContactsWebService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsWebService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactsAPI dbContext;
        public ContactsController(ContactsAPI dbContext) {
            this.dbContext = dbContext;
        }

        public ContactsAPI DbContext { get; }


        //fetch Specific Contact from DataBase        
        [HttpGet]
        [Route("{id:guid}")]
        public async Task <IActionResult> GetContact([FromRoute] Guid id)
        {
            var contact = await dbContext.ContactsList.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
            
        }

        //fetch All contacts from DataBase
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await dbContext.ContactsList.ToListAsync());

        }

        //Add new Contact to dataBase
        [HttpPost]
        public async Task <IActionResult> AddContact(AddContactRequest addContactRequest)
        {
            var contact = new Contacts()
            {

               Id=Guid.NewGuid(),
                FullName = addContactRequest.FullName,
                Email = addContactRequest.Email,
                Adress = addContactRequest.Adress,
                PhoneNumber = addContactRequest.PhoneNumber
            };
            await dbContext.ContactsList.AddAsync(contact);
           await dbContext.SaveChangesAsync();

            return Ok(contact);
        }


        //Update Contact from dataBase
        [HttpPut]
        [Route ("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id,UpdateContactRequest updateContact)
        {
            var contact = await dbContext.ContactsList.FindAsync(id);
            if (contact != null) 
            { 
            contact.FullName = updateContact.FullName;
            contact.Adress = updateContact.Adress;
                contact.PhoneNumber = updateContact.PhoneNumber;

                await dbContext.SaveChangesAsync(); 
                return Ok(contact);
            }
            return NotFound();
           
        }


        //Delete Contact from dataBase

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id
            )
        {
            var contact = await dbContext.ContactsList.FindAsync(id);
            if (contact != null)
            {
                 dbContext.Remove(contact);
                await dbContext.SaveChangesAsync();
                return Ok("Conatct Deleted Successfully");
            }
            return NotFound(nameof(contact));
        }
    }
}
