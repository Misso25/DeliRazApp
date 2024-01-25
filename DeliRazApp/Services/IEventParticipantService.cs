using DeliRazApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.Services
{
    public interface IEventParticipantService
    {
        Task<List<EventParticipantModel>> GetParticipantList(int id);
        Task<List<EventParticipantModel>> GetEventList(int id);

        Task<int> AddParticipantEvent(EventParticipantModel eventParticipantModel);
        Task<int> DeleteParticipantEvent(EventParticipantModel eventParticipantModel);
    }
}
