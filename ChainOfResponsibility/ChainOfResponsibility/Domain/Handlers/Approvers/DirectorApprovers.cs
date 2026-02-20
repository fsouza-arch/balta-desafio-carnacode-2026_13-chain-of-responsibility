using ChainOfResponsibility.Domain.Models;

namespace ChainOfResponsibility.Domain.Handlers.Approvers;

public class DirectorApprovers : ExpenseHandler
{
    public override void ProcessRequest(ExpenseRequest request)
    {
        if (request.Amount <= 5000)
        {
            if (ValidateReceipt(request) && CheckBudget(request.Department, request.Amount))
            {
                Console.WriteLine($"[Diretor] APROVOU despesa de R$ {request.Amount:N2} para {request.EmployeeName}");
            }
        }
        else if (_nextHandler != null)
        {
            Console.WriteLine("[Diretor] Valor acima do limite. Encaminhando para CEO...");
            _nextHandler.ProcessRequest(request);
        }
    }
}