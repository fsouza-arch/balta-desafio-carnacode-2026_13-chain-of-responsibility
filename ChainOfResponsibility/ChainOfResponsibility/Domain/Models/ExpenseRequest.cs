namespace ChainOfResponsibility.Domain.Models;

public class ExpenseRequest
{
    public string EmployeeName { get; set; }
    public decimal Amount { get; set; }
    public string Purpose { get; set; }
    public string Department { get; set; }

    public ExpenseRequest(string employeeName, decimal amount, string purpose, string department)
    {
        EmployeeName = employeeName;
        Amount = amount;
        Purpose = purpose;
        Department = department;
    }
}
