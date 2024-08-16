using System;
using System.Net.Http;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Newtonsoft.Json;
using MyFirstUI;
using System.Collections.Generic;

namespace MyFirstUI
{
    public sealed partial class MainPage : Page
    {
        private readonly HttpClient _httpClient;

        public MainPage()
        {
            this.InitializeComponent();
            _httpClient = new HttpClient();
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            var employee = new Employee
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Department = Department.Text,
                Email = Email.Text,
                Address = Address.Text,
                PhoneNumber = PhoneNumber.Text,
                DateOfBirth = DateTime.Parse(DateOfBirth.Text)
            };

            var json = JsonConvert.SerializeObject(employee);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync("http://localhost:5219/api/Employees", content);
        }

        private void ViewEmployee_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ViewEmployeePage));
        }
    }
}
