using ChainOfResponsibility.Domain.Models;

namespace ChainOfResponsibility.Domain.Handlers.Approvers;

public class ManagerApprovers : ExpenseHandler
{
    public override void ProcessRequest(ExpenseRequest request)
    {
        if (request.Amount <= 500)
        {
            if (ValidateReceipt(request) && CheckBudget(request.Department, request.Amount))
            {
                Console.WriteLine($"[Gerente] APROVOU despesa de R$ {request.Amount:N2} para {request.EmployeeName}");
            }
        }
        else if (_nextHandler != null)
        {
            Console.WriteLine("[Gerente] Valor acima do limite. Encaminhando para Diretor...");
            _nextHandler.ProcessRequest(request);
        }
    }
}