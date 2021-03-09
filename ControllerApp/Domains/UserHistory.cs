using System;

namespace ControllerApp.Domains
{
    public class UserHistory
    {
        public int UserHistoryId { get; set; }
        public string Action { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
