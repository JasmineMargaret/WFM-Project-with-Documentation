using WorkForceManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JasmineTask_Wfm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly SQLiteDBContext _context;
        public EmployeeController(SQLiteDBContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees>>> Get()
        {
            return await _context.Employees.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Employees>>> AddEmployee(Employees employee)
        {
            _context.Add(employee);
            try
            {
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, employee);
            }
            catch (DbUpdateException)
            {
                if (EmployeeExists(employee.employee_id))
                    return Conflict();
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, new
                    {
                        message = "Server Error"
                    });
            }
        }
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.employee_id == id);
        }
    }
}
