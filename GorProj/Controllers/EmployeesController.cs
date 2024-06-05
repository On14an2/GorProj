using GorProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GorProj.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly HoldingContext _context;

        static int aboba;


        static List<int> employeeIdSelect = new List<int>();

        public EmployeesController(HoldingContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var holdingContext = _context.Employees.Include(e => e.IdAppointmentNavigation).Include(e => e.IdEmployeeStatusNavigation);
            return View(await holdingContext.ToListAsync());
        }

        public async Task<IActionResult> Genocide()
        {
            var holdingContext = _context.Employees.Include(e => e.IdAppointmentNavigation).Include(e => e.IdEmployeeStatusNavigation);
            return View(await holdingContext.ToListAsync());
        }

        public async Task<IActionResult> GenocideAdd(Employee employee, int[] selected)
        {
            employeeIdSelect.AddRange(selected);
            _context.SaveChanges();

            foreach (var item in employeeIdSelect)
            {
                var employe = await _context.Employees.FindAsync(item);
                if (employe != null)
                {
                    _context.Employees.Remove(employe);
                }

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.IdAppointmentNavigation)
                .Include(e => e.IdEmployeeStatusNavigation)
                .FirstOrDefaultAsync(m => m.IdEmployee == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["IdAppointment"] = new SelectList(_context.Appointments, "IdAppointment", "IdAppointment");
            ViewData["IdEmployeeStatus"] = new SelectList(_context.EmployeeStatuses, "IdEmployeeStatus", "IdEmployeeStatus");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmployee,IdAppointment,IdEmployeeStatus,NameEmployee,FamilyEmployee,PatronymicEmployee,GenderEmployee,BirthdayEmployee")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAppointment"] = new SelectList(_context.Appointments, "IdAppointment", "IdAppointment", employee.IdAppointment);
            ViewData["IdEmployeeStatus"] = new SelectList(_context.EmployeeStatuses, "IdEmployeeStatus", "IdEmployeeStatus", employee.IdEmployeeStatus);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["IdAppointment"] = new SelectList(_context.Appointments, "IdAppointment", "IdAppointment", employee.IdAppointment);
            ViewData["IdEmployeeStatus"] = new SelectList(_context.EmployeeStatuses, "IdEmployeeStatus", "IdEmployeeStatus", employee.IdEmployeeStatus);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmployee,IdAppointment,IdEmployeeStatus,NameEmployee,FamilyEmployee,PatronymicEmployee,GenderEmployee,BirthdayEmployee")] Employee employee)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.IdEmployee))
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
            ViewData["IdAppointment"] = new SelectList(_context.Appointments, "IdAppointment", "IdAppointment", employee.IdAppointment);
            ViewData["IdEmployeeStatus"] = new SelectList(_context.EmployeeStatuses, "IdEmployeeStatus", "IdEmployeeStatus", employee.IdEmployeeStatus);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.IdAppointmentNavigation)
                .Include(e => e.IdEmployeeStatusNavigation)
                .FirstOrDefaultAsync(m => m.IdEmployee == id);
            if (employee == null)
            {
                return NotFound();
            }
            aboba = (int)id;
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed()
        {
            var employee = await _context.Employees.FindAsync(aboba);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.IdEmployee == id);
        }
    }
}
