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
    public class DepartmentsController : ControllerBase
    {
        private readonly TestDepartmentContext _testdepartmentcontext;
        public DepartmentsController(TestDepartmentContext testdepartmentcontext)
        {
            this._testdepartmentcontext = testdepartmentcontext;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var departments = await _testdepartmentcontext.Departments.ToListAsync();
            if (departments == null || departments.Count == 0)
            {
                return NotFound();
            }
            return departments;
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await _testdepartmentcontext.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return department;
        }



        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            _testdepartmentcontext.Departments.Add(department);
            await _testdepartmentcontext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDepartment), new { id = department.DepartmentId }, department);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult> PutDepartment(int id, Department department)
        {
            if (id != department.DepartmentId)
            {
                return BadRequest();
            }

            _testdepartmentcontext.Entry(department).State = EntityState.Modified;

            try
            {
                await _testdepartmentcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            var department = await _testdepartmentcontext.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }



            _testdepartmentcontext.Departments.Remove(department);
            await _testdepartmentcontext.SaveChangesAsync();



            return Ok();
        }
    }
}