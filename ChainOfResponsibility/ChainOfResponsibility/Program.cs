using ChainOfResponsibility.Domain.Handlers.Approvers;
using ChainOfResponsibility.Domain.Models;

Console.WriteLine("=== Sistema de Aprovação (Chain of Responsibility) ===\n");

// Montando a corrente (Pode ser feito via Injeção de Dependência)
var supervisor = new SupervisorApprovers();
var manager = new ManagerApprovers();
var director = new DirectorApprovers();
var ceo = new CEOApprovers();

supervisor.SetNext(manager);
manager.SetNext(director);
director.SetNext(ceo);

// Testando diferentes valores
var r1 = new ExpenseRequest("João", 80, "Café", "TI");
var r2 = new ExpenseRequest("Maria", 450, "Curso", "RH");
var r3 = new ExpenseRequest("Pedro", 2500, "Notebook", "TI");
var r4 = new ExpenseRequest("Ana", 15000, "Servidor", "TI");

Console.WriteLine("--- Processando Pedido 1 ---");
supervisor.ProcessRequest(r1);

Console.WriteLine("\n--- Processando Pedido 2 ---");
supervisor.ProcessRequest(r2);

Console.WriteLine("\n--- Processando Pedido 3 ---");
supervisor.ProcessRequest(r3);

Console.WriteLine("\n--- Processando Pedido 4 ---");
supervisor.ProcessRequest(r4);
