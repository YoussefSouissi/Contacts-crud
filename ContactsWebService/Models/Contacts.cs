namespace ContactsWebService.Models
{
    public class Contacts
    {
        public Guid Id { get; set; }    
        public string FullName { get; set; }    

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Adress { get; set; }
    }
}
