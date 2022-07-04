using EmployeeCrud.Data.Models;
using EmployeeCrud.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.Controllers;

public class DepartmentsController : Controller
{
    private readonly IDepartmentCrudService _departmentCrudService;
    private readonly ILogger<DepartmentsController> _logger;

    public DepartmentsController(
        IDepartmentCrudService departmentCrudService,
        ILogger<DepartmentsController> logger)
    {
        _departmentCrudService = departmentCrudService;
        _logger = logger;
        //_context = context;
    }

    // GET: Departments
    public async Task<IActionResult> Index()
    {
        try
        {
            var departments = await _departmentCrudService.GetAllAsync();
            return View(departments);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error in GetAll");
            return Problem("Error in GetAll");
        }
    }

    // GET: Departments/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var department = await _departmentCrudService.GetByIdAsync((int)id);

        if (department == null)
        {
            return NotFound();
        }

        return View(department);
    }

    // GET: Departments/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Departments/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Department department)
    {
        if (ModelState.IsValid)
        {
            await _departmentCrudService.CreateAsync(department);
            return RedirectToAction(nameof(Index));
        }
        return View(department);
    }

    // GET: Departments/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var department = await _departmentCrudService.GetByIdAsync((int) id);
        if (department == null)
        {
            return NotFound();
        }
        return View(department);
    }

    // POST: Departments/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Department department)
    {
        if (id != department.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _departmentCrudService.UpdateAsync(department);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await _departmentCrudService.Exists(department.Id))
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
        return View(department);
    }

    // GET: Departments/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var department = await _departmentCrudService.GetByIdAsync((int) id);
        if (department == null)
        {
            return NotFound();
        }

        return View(department);
    }

    // POST: Departments/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _departmentCrudService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }

}