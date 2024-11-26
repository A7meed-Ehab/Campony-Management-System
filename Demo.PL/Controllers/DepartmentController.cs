﻿using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _employeeRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _employeeRepository = departmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _employeeRepository.GetAllAsync();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department model)
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
                return BadRequest("Department ID is required.");

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
        public async Task<IActionResult> Edit(Department model)
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
            var department = await _employeeRepository.GetByIdAsync(id);
            if (department == null)
                return NotFound();

            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Department department)
        {
            if (department == null)
                return NotFound();
            try
            {
                await _employeeRepository.DeleteAsync(department);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(department);
            }
        }
    }
}
