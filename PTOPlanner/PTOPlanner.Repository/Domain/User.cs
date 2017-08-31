using System;

namespace PTOPlanner.Repository.Domain
{
    public class User
    {
        public int Employee_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Login_ID { get; set; }
        public string Password { get; set; }
        public DateTime? Start_Date { get; set; }
        public int? Annual_PTO_Days { get; set; }
        public decimal? Current_PTO_Hrs__Balance { get; set; }
        public DateTime? Added_DT { get; set; }
    }
}
