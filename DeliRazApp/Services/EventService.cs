using DeliRazApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.Services
{
    public class EventService : IEventService
    {
        private SQLiteAsyncConnection _dbConnection;

        public EventService()
        {
            SetUpDb();
        }

        private void SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RazDeli.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                _dbConnection.CreateTableAsync<EventModel>();
            }
        }

        public Task<List<EventModel>> GetEventList()
        {
            var eventList = _dbConnection.Table<EventModel>().ToListAsync();
            return eventList;
        }
        public Task<EventModel> GetEventListByID(int id)
        {
            var eventList = _dbConnection.Table<EventModel>().Where(x => x.EventID == id).FirstOrDefaultAsync();
            return eventList;
        }

        public Task<int> AddEvent(EventModel eventModel)
        {
            return _dbConnection.InsertAsync(eventModel);
        }

        public Task<int> DeleteEvent(EventModel eventModel)
        {
            return _dbConnection.DeleteAsync(eventModel);
        }

        public Task<int> UpdateEvent(EventModel eventModel)
        {
            return _dbConnection.UpdateAsync(eventModel);
        }
    }
}
