using DeliRazApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.Services
{
    public class EventParticipantService : IEventParticipantService
    {
        private SQLiteAsyncConnection _dbConnection;

        public EventParticipantService()
        {
            SetUpDb();
        }

        private void SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RazDeli.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                _dbConnection.CreateTableAsync<EventParticipantModel>();
            }
        }

        public Task<int> AddParticipantEvent(EventParticipantModel eventParticipantModel)
        {
            return _dbConnection.InsertAsync(eventParticipantModel);
        }

        public Task<int> DeleteParticipantEvent(EventParticipantModel eventParticipantModel)
        {
            return _dbConnection.DeleteAsync(eventParticipantModel);
        }

        public Task<List<EventParticipantModel>> GetParticipantList(int id)
        {
            var eventParticipantList = _dbConnection.Table<EventParticipantModel>().Where(x => x.EventID == id).ToListAsync();
            return eventParticipantList;
        }
        public Task<List<EventParticipantModel>> GetEventList(int id)
        {
            var eventParticipantList = _dbConnection.Table<EventParticipantModel>().Where(x => x.ParticipantID == id).ToListAsync();
            return eventParticipantList;
        }
    }
}
