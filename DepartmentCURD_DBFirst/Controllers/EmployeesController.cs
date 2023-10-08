using DepartmentCURD_DBFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentCURD_DBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly TestDepartmentContext _testDepartmentContext;
        public EmployeesController(TestDepartmentContext testDepartmentContext)
        {
            this._testDepartmentContext = testDepartmentContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _testDepartmentContext.Employees.ToListAsync();
            if (employees == null || employees.Count == 0)
            {
                return NotFound();
            }
            return employees;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _testDepartmentContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _testDepartmentContext.Employees.Add(employee);
            await _testDepartmentContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            _testDepartmentContext.Entry(employee).State = EntityState.Modified;

            try
            {
                await _testDepartmentContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var employee = await _testDepartmentContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _testDepartmentContext.Employees.Remove(employee);
            await _testDepartmentContext.SaveChangesAsync();

            return Ok();
        }
    }
}
