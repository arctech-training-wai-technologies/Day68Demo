using EmployeeCrud.Data.Models;
using EmployeeCrud.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.Controllers;

public class SalariesController : Controller
{
    private readonly ISalaryCrudService _salaryCrudService;
    private readonly ILogger<SalariesController> _logger;

    public SalariesController(
        ISalaryCrudService salaryCrudService,
        ILogger<SalariesController> logger)
    {
        _salaryCrudService = salaryCrudService;
        _logger = logger;
        //_context = context;
    }

    // GET: Salaries
    public async Task<IActionResult> Index()
    {
        try
        {
            var salaries = await _salaryCrudService.GetAllAsync();
            return View(salaries);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error in GetAll");
            return Problem("Error in GetAll");
        }
    }

    // GET: Salaries/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var salary = await _salaryCrudService.GetByIdAsync((int)id);

        if (salary == null)
        {
            return NotFound();
        }

        return View(salary);
    }

    // GET: Salaries/Create
    public async Task<IActionResult> Create()
    {
        ViewData["EmployeeRefId"] = new SelectList(await _salaryCrudService.GetEmployeeForDropDownAsync(), "Id", "Name");
        return View();
    }

    // POST: Salaries/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Salary salary)
    {
        if (ModelState.IsValid)
        {
            await _salaryCrudService.CreateAsync(salary);
            return RedirectToAction(nameof(Index));
        }

        ViewData["EmployeeRefId"] = new SelectList(await _salaryCrudService.GetEmployeeForDropDownAsync(), "Id", "Name");
        return View(salary);
    }

    // GET: Salaries/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var salary = await _salaryCrudService.GetByIdAsync((int) id);
        if (salary == null)
        {
            return NotFound();
        }

        ViewData["EmployeeRefId"] = new SelectList(await _salaryCrudService.GetEmployeeForDropDownAsync(), "Id", "Name");
        return View(salary);
    }

    // POST: Salaries/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Salary salary)
    {
        if (id != salary.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _salaryCrudService.UpdateAsync(salary);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await _salaryCrudService.ExistsAsync(salary.Id))
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

        ViewData["EmployeeRefId"] = new SelectList(await _salaryCrudService.GetEmployeeForDropDownAsync(), "Id", "Name");
        return View(salary);
    }

    // GET: Salaries/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var salary = await _salaryCrudService.GetByIdAsync((int) id);
        if (salary == null)
        {
            return NotFound();
        }

        return View(salary);
    }

    // POST: Salaries/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _salaryCrudService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }

}