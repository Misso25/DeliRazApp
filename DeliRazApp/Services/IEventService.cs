using DeliRazApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.Services
{
    public interface IEventService
    {
        Task<List<EventModel>> GetEventList();
        Task<EventModel> GetEventListByID(int id);

        Task<int> AddEvent(EventModel eventModel);
        Task<int> DeleteEvent(EventModel eventModel);
        Task<int> UpdateEvent(EventModel eventModel);
    }
}
