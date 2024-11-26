using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Models;
using Demo.PL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeController(IEmployeeRepository employeeRepository,IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            this._departmentRepository = departmentRepository;
        }
        public async Task<IActionResult> Index()
        {

            var departments = await _employeeRepository.GetAllAsync(nameof(Department));
            return View(departments);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //ViewBag.Departments = _departmentRepository.GetAllAsync();
            //var dept = new CreateEmployeeVM()
            //{
            //    Departments = await _departmentRepository.GetAllAsync()
            //};

            ViewData["Departments"] =await  _departmentRepository.GetAllAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee model)
        {

            if (ModelState.IsValid)
            {
                await _employeeRepository.AddAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Details(int? id, string viewName = "Details")
        {
            if (!id.HasValue)
                return BadRequest("Employee ID is required.");

            var department = await _employeeRepository.GetByIdAsync(id.Value);
            if (department == null)
                return NotFound();

            return View(viewName, department);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var department = await _employeeRepository.GetByIdAsync(id);
            if (department == null)
                return NotFound();
                return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeRepository.UpdateAsync(model);
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var Employee = await _employeeRepository.GetByIdAsync(id);
            if (Employee == null)
                return NotFound();
                return View(Employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Employee model)
        {
            if (model == null)
                return NotFound();
            try
            {
                await _employeeRepository.DeleteAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }
    }
}