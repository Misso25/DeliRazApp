using SQLite;

namespace DeliRazApp.Models
{
    public class EventModel
    {
        [PrimaryKey]
        public int EventID { get; set; }
        public string EventName {  get; set; }
        public DateTime EventDate { get; set; }
    }
}
