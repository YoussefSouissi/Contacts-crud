namespace ContactsWebService.Models
{
    public class AddContactRequest
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Adress { get; set; }
    }
}
