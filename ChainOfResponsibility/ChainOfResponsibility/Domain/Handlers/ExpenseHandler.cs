using ChainOfResponsibility.Domain.Models;

namespace ChainOfResponsibility.Domain.Handlers;

public abstract class ExpenseHandler
{
    protected ExpenseHandler _nextHandler;

    public void SetNext(ExpenseHandler nextHandler)
    {
        _nextHandler = nextHandler;
    }

    public abstract void ProcessRequest(ExpenseRequest request);

    // Métodos auxiliares comuns a todos os aprovadores
    protected bool ValidateReceipt(ExpenseRequest request)
    {
        Console.WriteLine($"  [Validando] Nota fiscal de {request.EmployeeName}...");
        return true;
    }

    protected bool CheckBudget(string department, decimal amount)
    {
        Console.WriteLine($"  [Orçamento] Verificando verba para {department}...");
        return true;
    }
}
