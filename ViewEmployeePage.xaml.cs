using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Windows.UI.Xaml.Controls;
using MyFirstUI;

namespace MyFirstUI
{
    public sealed partial class ViewEmployeePage : Page
    {
        private readonly HttpClient _httpClient;

        public ViewEmployeePage()
        {
            this.InitializeComponent();
            _httpClient = new HttpClient();
            LoadEmployees();
        }

        private async void LoadEmployees()
        {
            var response = await _httpClient.GetStringAsync("http://localhost:5219/api/Employees");
            var employees = JsonConvert.DeserializeObject<List<Employee>>(response);
            EmployeeListView.ItemsSource = employees;
        }

    }
}
