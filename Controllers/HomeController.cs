using Microsoft.AspNetCore.Mvc;
using NexusApp.Models;

namespace NexusApp.Controllers;

public class HomeController : Controller
{
    private static ConnectionFormData _formData = new();

    public IActionResult Index()
    {
        return View(_formData);
    }

    [HttpPost]
    public IActionResult SaveFormData([FromBody] SaveFormRequest request)
    {
        if (request?.Step == 1)
        {
            _formData.ServiceType = request.ServiceType ?? "Dial-Up";
        }
        else if (request?.Step == 2)
        {
            _formData.Plan = request.Plan ?? "Select Plan";
        }
        else if (request?.Step == 3)
        {
            _formData.CustomerName = request.CustomerName ?? "";
            _formData.PhoneNumber = request.PhoneNumber ?? "";
            _formData.Email = request.Email ?? "";
        }
        else if (request?.Step == 4)
        {
            _formData.Address = request.Address ?? "";
            _formData.City = request.City ?? "";
            _formData.PostalCode = request.PostalCode ?? "";
        }

        return Json(new { success = true });
    }

    [HttpPost]
    public IActionResult SubmitForm()
    {
        TempData["SuccessMessage"] = $"Application submitted successfully for {_formData.CustomerName}!";
        _formData = new ConnectionFormData();
        return Json(new { success = true, message = "Application submitted!" });
    }
}

public class SaveFormRequest
{
    public int Step { get; set; }
    public string? ServiceType { get; set; }
    public string? Plan { get; set; }
    public string? CustomerName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
}