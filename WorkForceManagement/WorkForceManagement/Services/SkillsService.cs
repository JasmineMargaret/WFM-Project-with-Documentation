using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkForceManagement.Models;

namespace WorkForceManagement.Services
{
    public interface ISkillsService
    {
        Task<IEnumerable<Skillswithemployees>> GetAllSkills();

    }
    public class SkillsService : ISkillsService
    {
        private readonly SQLiteDBContext _context;
        public SkillsService(SQLiteDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Skillswithemployees>> GetAllSkills()
        {
            var result = await _context.Skills.Include(x => x.skillmaps).ThenInclude(x => x.skills).Select(x => new Skillswithemployees
            {
                skillid = x.skillid,
                skillname = x.skillname,
                Employees = x.skillmaps.Select(y => y.employees.employee_name).ToList()
            }).ToListAsync();
            return result;
        }
    }
}