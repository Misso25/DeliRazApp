using DeliRazApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.Services
{
    public interface IExpenseService
    {
        Task<List<ExpenseModel>> GetExpenseList();
        Task<List<ExpenseModel>> GetExpenseListInEvent(int id);

        Task<int> AddExpense(ExpenseModel expenseModel);
        Task<int> DeleteExpense(ExpenseModel expenseModel);
        Task<int> UpdateExpense(ExpenseModel expenseModel);
    }
}
