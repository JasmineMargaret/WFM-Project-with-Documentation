using WorkForceManagement.Helpers;
using WorkForceManagement.Models;
using WorkForceManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WorkForceManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SoftlockController : ControllerBase
    {
        private readonly SQLiteDBContext _context;
        private readonly IEmployeesService _employeeService;

        public SoftlockController(SQLiteDBContext context, IEmployeesService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }
        [HttpPost("Lockrequest")]
        public IActionResult Lockrequest(SoftLock model)
        {
            model.Lastupdated = System.DateTime.Now;
            model.Reqdate = System.DateTime.Now;
            model.Mgrlastupdate = System.DateTime.Now;
            _context.Add(model);
            try
            {
                _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created, model);
            }

            catch (DbUpdateException)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Server Error"
                });
            }
        }

        [HttpGet]
        [Route("GetLocks")]
        public async Task<ActionResult<IEnumerable<SoftLock>>> GetLocks()
        {

            return await _context.SoftLocks.ToListAsync();
        }
        [HttpPost("Approverequest")]
        public async Task<IActionResult> Approverequest(SoftLock model)
        {
            Employees employees = this._employeeService.GetAgainstId(model.EmployeeId);
            employees.lockstatus = model.Status.Split(',')[1];
            model.Status = model.Status.Split(',')[0];
            model.Lastupdated = System.DateTime.Now;
            _context.Entry(model).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, model);
            }
            catch (DbUpdateException)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "Server Error"
                });
            }
        }
    }
}
