using DeliRazApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.Services
{
    public class DebtService : IDebtService
    {
        private SQLiteAsyncConnection _dbConnection;

        public DebtService()
        {
            SetUpDb();
        }

        private void SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RazDeli.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                _dbConnection.CreateTableAsync<DebtModel>();
            }
        }

        public Task<int> AddDebt(DebtModel debtModel)
        {
            return _dbConnection.InsertAsync(debtModel);
        }

        public Task<int> DeleteDebt(DebtModel debtModel)
        {
            return _dbConnection.DeleteAsync(debtModel);
        }

        public Task<List<DebtModel>> GetDebtListByExpenseID(int id)
        {
            var debtList = _dbConnection.Table<DebtModel>().Where(x => x.DebtExpenseID == id).ToListAsync();
            return debtList;
        }
        public Task<List<DebtModel>> GetDebtListByEventID(int id)
        {
            var debtList = _dbConnection.Table<DebtModel>().Where(x => x.DebtEventID == id).ToListAsync();
            return debtList;
        }

        public Task<int> UpdateDebt(DebtModel debtModel)
        {
            return _dbConnection.UpdateAsync(debtModel);
        }
    }
}
