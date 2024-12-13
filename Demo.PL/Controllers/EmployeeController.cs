using Demo.BLL.Interfaces;
using AutoMapper;
using Demo.BLL.Repositories;
using Demo.DAL.Models;
using Demo.PL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Demo.PL.Helpers;
using System.Collections;
using System.Collections.Generic;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IMapper mapper,IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork= unitOfWork;
        }
        public async Task<IActionResult> Index(string searchKey = "")
        {
           var employees = await _unitOfWork.EmployeeRepository.GetAllAsync(e=>e.Name.ToLower().Contains(searchKey.ToLower()) ,nameof(Department));
           return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //var dept = new CreateEmployeeVM()
            //{
            //    Departments = await _unitOfWork.EmployeeRepository.GetAllAsync()
            //};

            ViewData["Departments"] =await  _unitOfWork.DepartmentRepository.GetAllAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmployeeViewModel Vmodel)
        {
            if (ModelState.IsValid)
            {
                Vmodel.ImageName = DocumentSettings.UploadFile(Vmodel.Image, "images");
                var MappedEmployee = _mapper.Map<Employee>(Vmodel);
                MappedEmployee.Department =await _unitOfWork.DepartmentRepository.GetByIdAsync(Vmodel.DepartmentId);
                await _unitOfWork.EmployeeRepository.AddAsync(MappedEmployee);
                var complete=  _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Departments"] = await _unitOfWork.DepartmentRepository.GetAllAsync();
            return View(Vmodel);
        }

        public async Task<IActionResult> Details(int? id, string viewName = "Details")
        {
            if (!id.HasValue)
                return BadRequest("Employee ID is required.");

            var department = await _unitOfWork.EmployeeRepository.GetByIdAsync(id.Value);
            if (department == null)
                return NotFound();

            return View(viewName, department);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var department = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
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
                    await _unitOfWork.EmployeeRepository.UpdateAsync(model);
                _unitOfWork.Complete();

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
            var Employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
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
                await _unitOfWork.EmployeeRepository.DeleteAsync(model);
                _unitOfWork.Complete();

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