using DeliRazApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.Services
{
    public interface IDebtService
    {
        Task<List<DebtModel>> GetDebtListByExpenseID(int id);
        Task<List<DebtModel>> GetDebtListByEventID(int id);

        Task<int> AddDebt(DebtModel debtModel);
        Task<int> DeleteDebt(DebtModel debtModel);
        Task<int> UpdateDebt(DebtModel debtModel);
    }
}
