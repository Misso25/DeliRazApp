using DeliRazApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.Services
{
    public class ExpenseService : IExpenseService
    {
        private SQLiteAsyncConnection _dbConnection;

        public ExpenseService()
        {
            SetUpDb();
        }

        private void SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RazDeli.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                _dbConnection.CreateTableAsync<ExpenseModel>();
            }
        }

        public Task<int> AddExpense(ExpenseModel expenseModel)
        {
            return _dbConnection.InsertAsync(expenseModel);
        }

        public Task<int> DeleteExpense(ExpenseModel expenseModel)
        {
            return _dbConnection.DeleteAsync(expenseModel);
        }

        public Task<List<ExpenseModel>> GetExpenseList()
        {
            var expenseList = _dbConnection.Table<ExpenseModel>().ToListAsync();
            return expenseList;
        }

        public Task<int> UpdateExpense(ExpenseModel expenseModel)
        {
            return _dbConnection.UpdateAsync(expenseModel);
        }

        public Task<List<ExpenseModel>> GetExpenseListInEvent(int eventID)
        {
            var expenseList = _dbConnection.Table<ExpenseModel>().Where(x => x.ExpenseEventID == eventID).ToListAsync();
            return expenseList;
        }
    }
}
