using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Models.models;
using WebApplication2.Models.view;

namespace WebApplication2.Controllers;

public class TicketController : Controller
{
    private static List<Ticket> _tickets = new();

    [HttpGet]
    public IActionResult Index1()
    {
        return View(_tickets);
    }

    [HttpGet]
    public IActionResult Index()
    {
        ViewData[Constant.Departments] = Department.GetDepartments()
            .Select(d => new SelectListItem(d.Name, d.Id.ToString()))
        .ToList();

        ViewBag.Award = Award.GetAwards()
          .Select(d => new SelectListItem(d.Name, d.Id.ToString()))
          .ToList();

        return View();
    }

    [HttpPost]
    public IActionResult Add(TicketAddVM TicketVM)
    {
        var selectedAwards = Award.GetAwards()
            .Where(a => TicketVM.AwardIds.Contains(a.Id))
            .ToList();

        var selectedDepartment = Department.GetDepartments()
           .First(c => c.Id == TicketVM.Department_id);

        Ticket ticket = new Ticket
        {
            id = Guid.NewGuid(),
            CreatedDate = TicketVM.CreatedDate,
            IsClosed = TicketVM.IsClosed,
            Description = TicketVM.Description,
            Department_id = TicketVM.Department_id,
            Severity = TicketVM.Severity,
            Department = selectedDepartment,
            AwardsIds = selectedAwards
        };

        _tickets.Add(ticket);
        TempData[Constant.Operation] = Constant.Add;
        return RedirectToAction(nameof(Index1));
    }

    [HttpGet]
    public IActionResult Edit(Guid id)
    {
        Ticket ticket = _tickets.First(t => t.id == id);
        TicketEditVM TicketEditVM = new()
        {
            id = ticket.id,
            CreatedDate = ticket.CreatedDate,
            IsClosed = ticket.IsClosed,
            Description = ticket.Description,
            Department_id = ticket.Department_id,
            Severity = ticket.Severity,
            Department = ticket.Department!,
            AwardIds = ticket.AwardsIds.Select(award => award.Id).ToList()
        };

        ViewData[Constant.Departments] = Department.GetDepartments()
        .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
        .ToList();

        ViewBag.Awards = Award.GetAwards()
            .Select(a => new SelectListItem(a.Name, a.Id.ToString()))
            .ToList();

        return View(TicketEditVM);
    }

    [HttpPost]
    public IActionResult Edit(TicketEditVM ticketVM)
    {
        var selectedAwards = Award.GetAwards()
           .Where(a => ticketVM.AwardIds.Contains(a.Id))
           .ToList();
        var selectedDepartment = Department.GetDepartments()
           .First(c => c.Id == ticketVM.Department_id);

        var ticket = _tickets.First(t => t.id == ticketVM.id);

        ticket.id = ticketVM.id;
        ticket.Description = ticketVM.Description;
        ticket.IsClosed = ticketVM.IsClosed;
        ticket.Severity = ticketVM.Severity;
        ticket.Department = selectedDepartment;
        ticket.AwardsIds = selectedAwards;

        TempData[Constant.Operation] = Constant.Edit;

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Delete(Guid id)
    {
        var ticketToRemove = _tickets.First(a => a.id == id);
        _tickets.Remove(ticketToRemove);

        TempData[Constant.Operation] = Constant.Delete;

        return RedirectToAction(nameof(Index));
    }
}