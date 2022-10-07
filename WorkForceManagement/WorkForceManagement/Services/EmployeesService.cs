using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkForceManagement.Models;

namespace WorkForceManagement.Services
{
    public interface IEmployeesService
    {
        Task<IEnumerable<Employeeswithskills>> GetAllEmployees();
        Employees GetAgainstId(int id);
    }
    public class EmployeesService : IEmployeesService
    {
        private readonly SQLiteDBContext _context;
        public EmployeesService(SQLiteDBContext context)
        {
            _context = context;
        }
        public Employees GetAgainstId(int id)
        {
            return _context.Employees.FirstOrDefault(x => x.employee_id == id);
        }

        public async Task<IEnumerable<Employeeswithskills>> GetAllEmployees()
        {
            var result = await _context.Employees.Include(x => x.skillmaps).ThenInclude(x => x.skills).Select(x => new Employeeswithskills
            {
                employee_id = x.employee_id,
                employee_name = x.employee_name,
                status = x.status,
                manager = x.manager,
                wfm_manager = x.wfm_manager,
                email = x.email,
                experience = x.experience,
                lockstatus = x.lockstatus,
                Skills = x.skillmaps.Select(y => y.skills.skillname).ToList()
            }).ToListAsync();

            return result;
        }
    }
}