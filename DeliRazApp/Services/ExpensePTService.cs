using DeliRazApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.Services
{
    public class ExpensePTService : IExpensePTService
    {
        private SQLiteAsyncConnection _dbConnection;

        public ExpensePTService()
        {
            SetUpDb();
        }

        private void SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RazDeli.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                _dbConnection.CreateTableAsync<ExpensePTModel>();
            }
        }

        public Task<int> AddParticipantExpense(ExpensePTModel expensePTModel)
        {
            return _dbConnection.InsertAsync(expensePTModel);
        }

        public Task<int> DeleteParticipantExpense(ExpensePTModel expensePTModel)
        {
            return _dbConnection.DeleteAsync(expensePTModel);
        }

        public Task<List<ExpensePTModel>> GetExpenseList(int id)
        {
            var expenseParticipantList = _dbConnection.Table<ExpensePTModel>().Where(x => x.ParticipantID == id).ToListAsync();
            return expenseParticipantList;
        }

        public Task<List<ExpensePTModel>> GetParticipantList(int id)
        {
            var expenseParticipantList = _dbConnection.Table<ExpensePTModel>().Where(x => x.ExpenseID == id).ToListAsync();
            return expenseParticipantList;
        }
    }
}
