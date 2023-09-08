using ContactApiDemo;
using ContactApiDemo.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

using Contact = ContactsApiDemo.Models.Contact;


namespace ContactsApiDemo
{
    public partial class MainPage : ContentPage
    {
        private const string ApiUrl = "https://localhost:7102/api/Contacts";

        public MainPage()
        {
            InitializeComponent();
            FetchContacts();
        }

        private async void FetchContacts()
        {
            try
            {
                var httpClient = new HttpClient();
                var contacts = await httpClient.GetFromJsonAsync<List<Contact>>(ApiUrl);
                contactsListView.ItemsSource = contacts; 
            }
            catch (Exception ex)
            {
               
                await DisplayAlert("Error", $"Error fetching contacts: {ex.Message}", "OK");
            }
        }

        private async void OnAddContactClicked(object sender, EventArgs e)
        {
            try
            {
                var httpClient = new HttpClient();

                var newContactRequest = new
                {
                    FullName = fullNameEntry.Text,
                    Email = emailEntry.Text,
                    Adress = addressEntry.Text,
                    PhoneNumber = phoneEntry.Text
                };

                var json = JsonSerializer.Serialize(newContactRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(ApiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                   
                    FetchContacts();
                    // Clear input fields
                    fullNameEntry.Text = "";
                    emailEntry.Text = "";
                    addressEntry.Text = "";
                    phoneEntry.Text = "";
                }
                else
                {
                    
                    await DisplayAlert("Error", $"Error adding contact: {response.ReasonPhrase}", "OK");
                }
            }
            catch (Exception ex)
            {
               
                await DisplayAlert("Error", $"Error adding contact: {ex.Message}", "OK");
            }
        }



        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            try
            {
                var button = sender as Button;
                var contactId = (Guid)button.CommandParameter;

                var httpClient = new HttpClient();
                var response = await httpClient.DeleteAsync($"{ApiUrl}/{contactId}");

                if (response.IsSuccessStatusCode)
                {
                    
                    await DisplayAlert("Success", $"Contact Deleted successfully", "OK");
                    FetchContacts(); // Refresh the contact list
                }
                else
                {
                  
                    await DisplayAlert("Error", $"Error deleting contact: {response.ReasonPhrase}", "OK");
                }
            }
            catch (Exception ex)
            {
               
                await DisplayAlert("Error", $"Error deleting contact: {ex.Message}", "OK");
            }
        }


        private async void OnUpdateClicked(object sender, EventArgs e)
        {
            if (contactsListView.SelectedItem is Contact selectedContact)
            {
                await Navigation.PushAsync(new UpdateContactPage(selectedContact));
                
            }
        }

        public Contact SelectedContact
        {
            get => SelectedContact;
            set
            {
                if (SelectedContact != value)
                {
                    SelectedContact = value;
                    OnPropertyChanged(); 

                   
                    if (SelectedContact != null)
                    {
                        fullNameEntry.Text = SelectedContact.FullName;
                        emailEntry.Text = SelectedContact.Email;
                        phoneEntry.Text = SelectedContact.PhoneNumber;
                        addressEntry.Text = SelectedContact.Adress;
                    }
                    else
                    {
                        
                        fullNameEntry.Text = "";
                        emailEntry.Text = "";
                        phoneEntry.Text = "";
                        addressEntry.Text = "";
                    }
                }
            }
        }

    }
}
