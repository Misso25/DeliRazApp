using SQLite;

namespace DeliRazApp.Models
{
    public class ExpenseModel
    {
        [PrimaryKey]
        public int ExpenseID {  get; set; }
        public string ExpenseName { get; set;}
        public string ExpenseCreditorName { get; set;}
        public int ExpenseAmount { get; set;}
        public int ExpenseEventID {  get; set;}
    }
}
