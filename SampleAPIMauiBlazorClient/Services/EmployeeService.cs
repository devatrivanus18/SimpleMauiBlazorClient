using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPIMauiBlazorClient.Services
{
    
    internal class EmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("apiClient");
        }

        // Get all employees
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Employee");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<List<Employee>>();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Get employee by ID
        public async Task<Employee> GetEmployeeAsync(long id)
        {
            var response = await _httpClient.GetAsync($"api/Employee/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Employee>();
        }

        // Add a new employee
        public async Task<bool> AddEmployeeAsync(Employee employee)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Employee", employee);
            return response.IsSuccessStatusCode;
        }

        // Update existing employee
        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Employee/{employee.EmployeeId}", employee);
            return response.IsSuccessStatusCode;
        }

        // Delete an employee
        public async Task<bool> DeleteEmployeeAsync(long id)
        {
            var response = await _httpClient.DeleteAsync($"api/Employee/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
