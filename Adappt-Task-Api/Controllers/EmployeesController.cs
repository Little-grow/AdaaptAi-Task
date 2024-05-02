using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int EmployeeId, EmploeeDto NewEmploee)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == EmployeeId);

            if (employee is null)
            {
                return NotFound();
            }

            employee.FirstName = NewEmploee.FirstName;
            employee.LastName = NewEmploee.LastName;
            employee.EmployeeCode = NewEmploee.EmployeeCode;
            employee.EmailAddress = NewEmploee.EmailAddress;

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(NewEmploee.Password);
            employee.PasswordHash = hashedPassword;

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int EmployeeId)
        {

            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == EmployeeId);

            if (employee is null)
            {
                return NotFound();
            }

             _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent(); // chec for this 
        }
    }
}
