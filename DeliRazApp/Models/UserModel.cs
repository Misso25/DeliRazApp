using SQLite;

namespace DeliRazApp.Models
{
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword {  get; set; }
        public string UserName { get; set; }
        public string UserPhoneNumber {  get; set; }
        public string UserBankName {  get; set; }
    }
}
