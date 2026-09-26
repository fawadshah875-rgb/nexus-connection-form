namespace NexusApp.Models;

public class ConnectionFormData
{
    public string ServiceType { get; set; } = "Dial-Up";
    public string Plan { get; set; } = "Select Plan";
    public string CustomerName { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string Email { get; set; } = "";
    public string Address { get; set; } = "";
    public string City { get; set; } = "";
    public string PostalCode { get; set; } = "";
}