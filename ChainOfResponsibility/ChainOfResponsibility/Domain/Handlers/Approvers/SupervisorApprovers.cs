using ChainOfResponsibility.Domain.Models;

namespace ChainOfResponsibility.Domain.Handlers.Approvers;

public class SupervisorApprovers : ExpenseHandler
{
    public override void ProcessRequest(ExpenseRequest request)
    {
        if (request.Amount <= 100)
        {
            if (ValidateReceipt(request) && CheckBudget(request.Department, request.Amount))
            {
                Console.WriteLine($"[Supervisor] APROVOU despesa de R$ {request.Amount:N2} para {request.EmployeeName}");
            }
        }
        else if (_nextHandler != null)
        {
            Console.WriteLine("[Supervisor] Valor acima do limite. Encaminhando para Gerente...");
            _nextHandler.ProcessRequest(request);
        }
    }
}
