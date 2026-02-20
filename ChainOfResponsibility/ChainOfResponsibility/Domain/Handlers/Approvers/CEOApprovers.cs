using ChainOfResponsibility.Domain.Models;

namespace ChainOfResponsibility.Domain.Handlers.Approvers;

public class CEOApprovers : ExpenseHandler
{
    public override void ProcessRequest(ExpenseRequest request)
    {
        if (ValidateReceipt(request) && CheckBudget(request.Department, request.Amount))
        {
            Console.WriteLine($"[CEO] APROVOU despesa de R$ {request.Amount:N2} para {request.EmployeeName}");
        }
        else
        {
            Console.WriteLine("[CEO] REJEITOU a despesa.");
        }
    }
}
