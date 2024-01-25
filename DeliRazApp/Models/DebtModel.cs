using SQLite;

namespace DeliRazApp.Models
{
    public class DebtModel
    {
        [PrimaryKey, AutoIncrement]
        public int DebtID {  get; set; }
        public string DebtCreditorLogin {  get; set; }
        public string DebtCreditorName {  get; set; }
        public string DebtDebtorLogin {  get; set; }
        public string DebtDebtorName {  get; set; }
        public int DebtEventID { get; set; }
        public int DebtExpenseID { get; set; }
        public int DebtAmount {  get; set; }
    }
}
