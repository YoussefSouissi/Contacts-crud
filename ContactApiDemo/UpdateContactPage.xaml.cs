

using System;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using ContactApiDemo.Models;
using Microsoft.Maui.Controls;
using Contact = ContactsApiDemo.Models.Contact;

namespace ContactApiDemo
{
    public partial class UpdateContactPage : ContentPage
    {
        private const string ApiUrl = "https://localhost:7102/api/Contacts";
        private readonly Contact selectedContact;

        public UpdateContactPage(Contact selectedContact)
        {
            InitializeComponent();
            this.selectedContact = selectedContact;

            fullNameEntry.Text = selectedContact.FullName;
            emailEntry.Text = selectedContact.Email;
            phoneEntry.Text = selectedContact.PhoneNumber;
            addressEntry.Text = selectedContact.Adress;
        }

        private async void OnUpdateClicked(object sender, EventArgs e)
        {
            try
            {
                var updateRequest = new UpdateContactRequest
                {
                    FullName = fullNameEntry.Text,
                    PhoneNumber = phoneEntry.Text,
                    Adress = addressEntry.Text
                };

                var httpClient = new HttpClient();
                var json = JsonSerializer.Serialize(updateRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync($"{ApiUrl}/{selectedContact.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                   
                    selectedContact.FullName = updateRequest.FullName;
                    selectedContact.PhoneNumber = updateRequest.PhoneNumber;
                    selectedContact.Adress = updateRequest.Adress;

                    await Navigation.PopAsync(); 
                }
                else
                {
                    await DisplayAlert("Error", $"Error updating contact: {response.ReasonPhrase}", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error updating contact: {ex.Message}", "OK");
            }
        }
    }
}
