using DeliRazApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.Services
{
    public interface IExpensePTService
    {
        Task<List<ExpensePTModel>> GetParticipantList(int id);
        Task<List<ExpensePTModel>> GetExpenseList(int id);

        Task<int> AddParticipantExpense(ExpensePTModel expensePTModel);
        Task<int> DeleteParticipantExpense(ExpensePTModel expensePTModel);
    }
}
