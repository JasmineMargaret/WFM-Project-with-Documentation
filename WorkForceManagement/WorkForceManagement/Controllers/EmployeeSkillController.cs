using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WorkForceManagement.Services;

namespace WorkForceManagement.Controllers
{
    public class EmployeeSkillController : Controller
    {
        private readonly IEmployeesService _employeeService;
        private readonly ISkillsService _skillService;

        public EmployeeSkillController(IEmployeesService employeeService, ISkillsService skillService)
        {
            _employeeService = employeeService;
            _skillService = skillService;
        }
        [HttpGet]
        [Route("GetEmployeesSkills")]
        public async Task<IActionResult> GetEmployeesSkills()
        {
            try
            {
                var result = await _employeeService.GetAllEmployees();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("GetSkillsEmployee")]
        public async Task<IActionResult> GetSkillsEmployee()
        {
            try
            {
                var result = await _skillService.GetAllSkills();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
