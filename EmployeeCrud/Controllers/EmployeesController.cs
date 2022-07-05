using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeCrud.Data;
using EmployeeCrud.Data.Models;
using EmployeeCrud.Services;
using EmployeeCrud.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeCrud.Controllers;

public class EmployeesController : Controller
{
    private readonly IEmployeeCrudService _employeeCrudService;
    private readonly ILogger<EmployeesController> _logger;

    public EmployeesController(
        IEmployeeCrudService employeeCrudService,
        ILogger<EmployeesController> logger)
    {
        _employeeCrudService = employeeCrudService;
        _logger = logger;
        //_context = context;
    }

    // GET: Employees
    public async Task<IActionResult> Index()
    {
        try
        {
            var employees = await _employeeCrudService.GetAllAsync();
            return View(employees);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error in GetAll");
            return Problem("Error in GetAll");
        }
    }

    // GET: Employees/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _employeeCrudService.GetByIdAsync((int)id);

        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    // GET: Employees/Create
    public async Task<IActionResult> Create()
    {
        ViewData["DepartmentRefId"] = new SelectList(await _employeeCrudService.GetDepartmentListForDropDownAsync(), "Id", "Name");
        return View();
    }

    // POST: Employees/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EmployeeViewModel employee)
    {
        if (ModelState.IsValid)
        {
            await _employeeCrudService.CreateAsync(employee);
            return RedirectToAction(nameof(Index));
        }

        ViewData["DepartmentRefId"] = new SelectList(await _employeeCrudService.GetDepartmentListForDropDownAsync(), "Id", "Name", employee.DepartmentRefId);

        return View(employee);
    }

    // GET: Employees/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _employeeCrudService.GetByIdAsync((int) id);
        if (employee == null)
        {
            return NotFound();
        }

        ViewData["DepartmentRefId"] = new SelectList(await _employeeCrudService.GetDepartmentListForDropDownAsync(), "Id", "Name", employee.DepartmentRefId);
        return View(employee);
    }

    // POST: Employees/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, EmployeeViewModel employee)
    {
        if (id != employee.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _employeeCrudService.UpdateAsync(employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await _employeeCrudService.ExistsAsync(employee.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        ViewData["DepartmentRefId"] = new SelectList(await _employeeCrudService.GetDepartmentListForDropDownAsync(), "Id", "Name", employee.DepartmentRefId);
        return View(employee);
    }

    // GET: Employees/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _employeeCrudService.GetByIdAsync((int) id);
        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    // POST: Employees/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _employeeCrudService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }
}