using Client.Pages;
using System.Net.Http.Json;
using static Client.Pages.Employees;

namespace Client.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
       
        public async Task<Employee[]> GetEmployees()
        {
            return await _httpClient.GetFromJsonAsync<Employee[]>("Employees") ?? new Employee[] { };
        }
    }
}
