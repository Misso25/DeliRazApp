using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliRazApp.Models
{
    public class EventParticipantModel
    {
        public int EventID { get; set; }
        public int ParticipantID { get; set; }
    }
}
