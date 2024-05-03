using static Client.Pages.Employees;

namespace Client.Services
{
    public interface IEmployeeService
    {
        Task<Employee[]> GetEmployees();
    }
}
